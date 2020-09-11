using DerectionSender.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DerectionSender.Presenters
{
    public class CreatePresenter : IPresenter
    {
        private readonly IDerectionSenderRepository _derectionSenderRepository;
        private readonly IDerectionSenderView _derectionSenderView;
        private delegate void EnableButtonDelegate();
        private delegate void ChangeStatusDelegate();
        public CreatePresenter(IDerectionSenderView derectionSenderView, IDerectionSenderRepository derectionSenderRepository)
        {
            this._derectionSenderRepository = derectionSenderRepository;
            this._derectionSenderView = derectionSenderView;
            this._derectionSenderView.InitComboboxies += () => Load();
            this._derectionSenderView.InitComboboxies += () => UpdateDataGrid();
            this._derectionSenderView.Create += () => Create();
            this._derectionSenderView.Start += () => SendEmails();
            this._derectionSenderView.DeleteAll += () => DeleteAll();
        }
        public void Run()
        {
            this._derectionSenderView.Show();
        }
        public void Load()
        {
            var countries = this._derectionSenderRepository.GetCountries().Where(y => !y.IsIndexPresent).Select(x => x.CountryName).ToArray();
            this._derectionSenderView.SubjectTextBox = ConfigurationManager.AppSettings["Subject"];
            this._derectionSenderView.RichEmailTextBox = ConfigurationManager.AppSettings["Body"];
            this._derectionSenderView.SetFromDerectionCombobox = countries;
            this._derectionSenderView.SetToDerectionCombobox = countries;
            this._derectionSenderView.EmailTextBox = ConfigurationManager.AppSettings["Email"]; 
            this._derectionSenderView.PasswordTextBox = ConfigurationManager.AppSettings["Pass"]; ;
        }

        public void Create()
        {
            if (String.IsNullOrEmpty(this._derectionSenderView.FromDerection) || String.IsNullOrEmpty(this._derectionSenderView.ToDerection))
            {
                this._derectionSenderView.ShowValidateError("Направления не могут быть пустыми.");
                return;
            }
            if (String.IsNullOrEmpty(this._derectionSenderView.SubjectTextBox))
            {
                this._derectionSenderView.ShowValidateError("Тема не может быть пустой.");
                return;
            }
            if (String.IsNullOrEmpty(this._derectionSenderView.RichEmailTextBox))
            {
                this._derectionSenderView.ShowValidateError("Текст письма не может быть пустым.");
                return;
            }
            var currentDerectionName = $"{this._derectionSenderView.FromDerection} - {this._derectionSenderView.ToDerection}";
            var currentDerections = this._derectionSenderRepository.GetDerections().ToList().FirstOrDefault(x => x.Derection == currentDerectionName);
            if (currentDerections.Contacts.Count > 1)
            {
                foreach (var item in currentDerections.Contacts)
                {
                    var rD = new RequestDerections
                    {
                        Id = Guid.NewGuid(),
                        FK_Derections = currentDerections.Id,
                        EmailBody = FormateEmailText(this._derectionSenderView.RichEmailTextBox, currentDerections, item),
                        CreatedAt = DateTime.Now,
                        FK_Contact = item.Id,
                        IsPost = false,
                        IsDeleted = false,
                        PostedAt = null,
                        Subject = FormateEmailText(this._derectionSenderView.SubjectTextBox, currentDerections, currentDerections.Contacts.FirstOrDefault())
                    };
                    this._derectionSenderRepository.Create(rD);
                }
            }
            else
            {
                var rD = new RequestDerections
                {
                    Id = Guid.NewGuid(),
                    FK_Derections = currentDerections.Id,
                    EmailBody = FormateEmailText(this._derectionSenderView.RichEmailTextBox, currentDerections, currentDerections.Contacts.FirstOrDefault()),
                    CreatedAt = DateTime.Now,
                    FK_Contact = currentDerections.Contacts.FirstOrDefault().Id,
                    IsPost = false,
                    IsDeleted = false,
                    PostedAt = null,
                    Subject = FormateEmailText(this._derectionSenderView.SubjectTextBox, currentDerections, currentDerections.Contacts.FirstOrDefault())
                };
                this._derectionSenderRepository.Create(rD);
            }
            UpdateDataGrid();
        }

        public void UpdateDataGrid()
        {
            this._derectionSenderView.ClearGrid();
            var requestDerectionsWithoutDeletedRows = this._derectionSenderRepository.GetRequestDerections().Where(x => !x.IsDeleted);
            foreach (var item in requestDerectionsWithoutDeletedRows)
            {
                this._derectionSenderView.AddRowToGrid(item.Derections.Derection, item.Contacts.Email, item.Subject, item.EmailBody, "Ready", item.IsPost);
            }
        }
        public string FormateEmailText(string text, Derections currentDerections, Contacts contact)
        {
            return text.Replace("{{@DerectionFrom}}", currentDerections.Countries.CountryName)
                .Replace("{{@DerectionTo}}", currentDerections.Countries1.CountryName)
                .Replace("{{@DerectionFromPrefix}}", currentDerections.Countries.Prefix)
                .Replace("{{@DerectionToPrefix}}", currentDerections.Countries1.Prefix)
                .Replace("{{@ContactName}}", contact.Name)
                .Replace("{{@Email}}", contact.Email)
                .Replace("{{@Phone}}", contact.Phone)
                .Replace("{{@Fax}}", contact.Fax)
                .Replace("{{@PostedDateTime}}", DateTime.Now.ToString());
        }
        public async void SendEmails()
        {
            if (String.IsNullOrEmpty(this._derectionSenderView.EmailTextBox) || String.IsNullOrEmpty(this._derectionSenderView.PasswordTextBox))
            {
                this._derectionSenderView.ShowValidateError("Почта и пароль должны быть заполнены.");
                return;
            }
            var requestDerections = this._derectionSenderRepository.GetRequestDerections().Where(x => !x.IsDeleted && !x.IsPost).ToList();
            if (requestDerections.Count == 0)
            {
                this._derectionSenderView.ShowValidateError("Создайте заявки.");
                return;
            }
            this._derectionSenderView.StartSendButton.Enabled = false;
            await Task.Run(() => {
                ParallelOptions po = new ParallelOptions();
                po.MaxDegreeOfParallelism = 15;
                Parallel.For(0, requestDerections.Count, po, (j) =>
                {
                    MailAddress to = new MailAddress(requestDerections[j].Contacts.Email);
                    MailAddress from = new MailAddress(this._derectionSenderView.EmailTextBox);
                    MailMessage mail = new MailMessage(from, to);
                    mail.Subject = requestDerections[j].Subject;

                    mail.Body = requestDerections[j].EmailBody;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.yandex.ru";
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(
                        this._derectionSenderView.EmailTextBox, this._derectionSenderView.PasswordTextBox);
                    smtp.EnableSsl = true;
                    this._derectionSenderView.GridInvoke(new ChangeStatusDelegate(() => this.ChangeStatus("Init Smtp", requestDerections[j])));
                    try
                    {
                        smtp.Send(mail);
                        var currentDerection = this._derectionSenderRepository.GetRequestDerections().ToList().FirstOrDefault(x => x.Id == requestDerections[j].Id);
                        currentDerection.IsPost = true;
                        this._derectionSenderRepository.SaveChanges();
                        this._derectionSenderView.GridInvoke(new ChangeStatusDelegate(() => this.ChangeStatus("Success", requestDerections[j])));
                    }
                    catch (Exception ex)
                    {
                        this._derectionSenderView.GridInvoke(new ChangeStatusDelegate(() => this.ChangeStatus(ex.Message, requestDerections[j])));
                    }
                });
                this._derectionSenderView.StartSendButton.Invoke(new EnableButtonDelegate(EnableStartButton));
            });
        }
        public void EnableStartButton()
        {
            this._derectionSenderView.StartSendButton.Enabled = true;
        }
        public void ChangeStatus(string text, RequestDerections requestDerections)
        {

            int rowIndex = this._derectionSenderView.GetGridIndexByCellValue("Text", requestDerections.EmailBody);
            if (rowIndex != -1)
            {
                if (text == "Init Smtp")
                {
                    this._derectionSenderView.ChangeValueAndColorCellByIndex(rowIndex, 4, text, Color.Yellow);
                    return;
                }
                if (text == "Success")
                {
                    this._derectionSenderView.ChangeValueAndColorCellByIndex(rowIndex, 4, text, Color.Green);
                    this._derectionSenderView.ChangeValueAndColorCellByIndex(rowIndex, 5, "True", Color.Green);
                    return;
                }
                this._derectionSenderView.ChangeValueAndColorCellByIndex(rowIndex, 5, text, Color.Red);
                return;
            }
        }

        public void DeleteAll()
        {
            this._derectionSenderRepository.DeleteAllDerections();
            UpdateDataGrid();
        }
    }
}
