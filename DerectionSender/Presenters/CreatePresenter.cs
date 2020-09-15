using DerectionSender.Repositories;
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
        private readonly IEmailRepository _emailRepository;
        private delegate void EnableButtonDelegate();
        private delegate void ChangeStatusDelegate();
        public CreatePresenter(IDerectionSenderView derectionSenderView, IDerectionSenderRepository derectionSenderRepository, IEmailRepository emailRepository)
        {
            this._derectionSenderRepository = derectionSenderRepository;
            this._emailRepository = emailRepository;
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
            var countries = this._derectionSenderRepository.GetCountriesNames().ToArray();
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
            var currentDerections = this._derectionSenderRepository.GetDerectionsByName(currentDerectionName);
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
            var requestDerectionsWithoutDeletedRows = this._derectionSenderRepository.GetRequestDerectionsIsNotDeleted();
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
            var requestDerections = this._derectionSenderRepository.GetRequestDerectionsIsNotDeletedIsNotPosted().ToList();
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
                    this._derectionSenderView.GridInvoke(new ChangeStatusDelegate(() => this.ChangeStatus("Create Smtp connection", requestDerections[j])));
                    var emailStatus = this._emailRepository
                    .SendEmail(
                        requestDerections[j].Contacts.Email,
                        this._derectionSenderView.EmailTextBox,
                        this._derectionSenderView.PasswordTextBox,
                        ConfigurationManager.AppSettings["Host"],
                        Convert.ToInt32(ConfigurationManager.AppSettings["Port"]),
                        requestDerections[j].Subject,
                        requestDerections[j].EmailBody
                        );
                    if (emailStatus == "success")
                    {
                        var currentDerection = this._derectionSenderRepository.GetRequestDerectionsById(requestDerections[j].Id);
                        currentDerection.IsPost = true;
                        currentDerection.PostedAt = DateTime.Now;
                        this._derectionSenderRepository.SaveChanges();
                        this._derectionSenderView.GridInvoke(new ChangeStatusDelegate(() => this.ChangeStatus("Success", requestDerections[j])));
                    }
                    else
                    {
                        this._derectionSenderView.GridInvoke(new ChangeStatusDelegate(() => this.ChangeStatus(emailStatus, requestDerections[j])));
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
                if (text == "Create Smtp connection")
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
