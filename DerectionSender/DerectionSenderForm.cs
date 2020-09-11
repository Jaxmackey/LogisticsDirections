using DerectionSender.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DerectionSender
{
    public partial class DerectionSenderForm : Form, IDerectionSenderView
    {
        public DerectionSenderForm()
        {
            InitializeComponent();
            buttonCreateSend.Click += (sender, args) => Invoke(Create);
            buttonStartSend.Click += (sender, args) => Invoke(Start);
            buttonDelete.Click += (sender, args) => Invoke(DeleteAll);
            this.Load += (sender, args) => Invoke(InitComboboxies);
        }

        public string FromDerection
        {
            get { return comboBoxFromCountry.Text; }
        }

        public string[] SetFromDerectionCombobox
        {
            set { comboBoxFromCountry.Items.AddRange(value); }
        }

        public string ToDerection
        {
            get { return comboBoxToCountry.Text; }
        }

        public string[] SetToDerectionCombobox
        {
            set { comboBoxToCountry.Items.AddRange(value); }
        }

        public string FromIndex
        {
            get { return textBoxFromIndex.Text; }
            set { textBoxFromIndex.Text = value; }
        }

        public string ToIndex {
            get { return textBoxToIndex.Text; }
            set { textBoxToIndex.Text = value; }
        }

        public string RichEmailTextBox
        {
            get { return richTextBoxEmail.Text; }
            set { richTextBoxEmail.Text = value; }
        }

        public DataGridView dataGrid {
            get { return dataGridViewSends; }
        }

        public void ClearGrid()
        {
            dataGridViewSends.Rows.Clear();
        }

        public void AddRowToGrid(params object[] cells)
        {
            dataGridViewSends.Rows.Add(cells);
        }

        public void GridInvoke(Delegate method)
        {
            dataGridViewSends.Invoke(method);
        }

        public int GetGridIndexByCellValue(string cellHeaderText, string cellInnerText)
        {
            DataGridViewRow row = dataGridViewSends.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells[cellHeaderText].Value.ToString().Equals(cellInnerText))
                .First();
            return row.Index;
        }

        public void ChangeValueAndColorCellByIndex(int rowIndex, int cellIndex, string status, Color color)
        {
            dataGridViewSends.Rows[rowIndex].Cells[cellIndex].Value = status;
            dataGridViewSends.Rows[rowIndex].Cells[cellIndex].Style.BackColor = Color.Green;
            return;
        }

        public string EmailTextBox
        {
            get { return textBoxEmailFrom.Text; }
            set { textBoxEmailFrom.Text = value; }
        }

        public string PasswordTextBox
        {
            get { return textBoxPassword.Text; }
            set { textBoxPassword.Text = value; }
        }

        public Button StartSendButton { get { return buttonStartSend; } }
        public string SubjectTextBox
        {
            get { return textBoxSubject.Text; }
            set { textBoxSubject.Text = value; }
        }

        public event Action Create;
        public event Action InitComboboxies;
        public event Action Start;
        public event Action DeleteAll;

        public void ShowValidateError(string message)
        {
            MessageBox.Show(message);
        }
        public new void Show()
        {
            Application.Run(this);
        }

        private void Invoke(Action action)
        {
            if (action != null) action();
        }
    }
}
