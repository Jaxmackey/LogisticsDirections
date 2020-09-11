namespace DerectionSender
{
    partial class DerectionSenderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DerectionSenderForm));
            this.groupBoxParams = new System.Windows.Forms.GroupBox();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.labelSubject = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxEmailFrom = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreateSend = new System.Windows.Forms.Button();
            this.richTextBoxEmail = new System.Windows.Forms.RichTextBox();
            this.labelEmeil = new System.Windows.Forms.Label();
            this.textBoxToIndex = new System.Windows.Forms.TextBox();
            this.labelToIndex = new System.Windows.Forms.Label();
            this.textBoxFromIndex = new System.Windows.Forms.TextBox();
            this.labelFromIndex = new System.Windows.Forms.Label();
            this.comboBoxToCountry = new System.Windows.Forms.ComboBox();
            this.labelToCountry = new System.Windows.Forms.Label();
            this.comboBoxFromCountry = new System.Windows.Forms.ComboBox();
            this.labelFromCountry = new System.Windows.Forms.Label();
            this.groupBoxSender = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStartSend = new System.Windows.Forms.Button();
            this.dataGridViewSends = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxParams.SuspendLayout();
            this.groupBoxSender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSends)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxParams
            // 
            this.groupBoxParams.Controls.Add(this.textBoxSubject);
            this.groupBoxParams.Controls.Add(this.labelSubject);
            this.groupBoxParams.Controls.Add(this.textBoxPassword);
            this.groupBoxParams.Controls.Add(this.labelPassword);
            this.groupBoxParams.Controls.Add(this.textBoxEmailFrom);
            this.groupBoxParams.Controls.Add(this.labelEmail);
            this.groupBoxParams.Controls.Add(this.label6);
            this.groupBoxParams.Controls.Add(this.label5);
            this.groupBoxParams.Controls.Add(this.label4);
            this.groupBoxParams.Controls.Add(this.label2);
            this.groupBoxParams.Controls.Add(this.label1);
            this.groupBoxParams.Controls.Add(this.buttonCreateSend);
            this.groupBoxParams.Controls.Add(this.richTextBoxEmail);
            this.groupBoxParams.Controls.Add(this.labelEmeil);
            this.groupBoxParams.Controls.Add(this.textBoxToIndex);
            this.groupBoxParams.Controls.Add(this.labelToIndex);
            this.groupBoxParams.Controls.Add(this.textBoxFromIndex);
            this.groupBoxParams.Controls.Add(this.labelFromIndex);
            this.groupBoxParams.Controls.Add(this.comboBoxToCountry);
            this.groupBoxParams.Controls.Add(this.labelToCountry);
            this.groupBoxParams.Controls.Add(this.comboBoxFromCountry);
            this.groupBoxParams.Controls.Add(this.labelFromCountry);
            this.groupBoxParams.Location = new System.Drawing.Point(13, 13);
            this.groupBoxParams.Name = "groupBoxParams";
            this.groupBoxParams.Size = new System.Drawing.Size(487, 500);
            this.groupBoxParams.TabIndex = 0;
            this.groupBoxParams.TabStop = false;
            this.groupBoxParams.Text = "Параметры";
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(14, 113);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(461, 20);
            this.textBoxSubject.TabIndex = 22;
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(11, 97);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(37, 13);
            this.labelSubject.TabIndex = 21;
            this.labelSubject.Text = "Тема:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(54, 470);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(140, 20);
            this.textBoxPassword.TabIndex = 20;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(9, 473);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(48, 13);
            this.labelPassword.TabIndex = 19;
            this.labelPassword.Text = "Пароль:";
            // 
            // textBoxEmailFrom
            // 
            this.textBoxEmailFrom.Location = new System.Drawing.Point(54, 444);
            this.textBoxEmailFrom.Name = "textBoxEmailFrom";
            this.textBoxEmailFrom.Size = new System.Drawing.Size(140, 20);
            this.textBoxEmailFrom.TabIndex = 18;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(17, 447);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(40, 13);
            this.labelEmail.TabIndex = 17;
            this.labelEmail.Text = "Почта:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 410);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "{{@PostedDateTime}}";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 397);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "{{@Phone}}; {{@Fax}}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 384);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "{{@ContactName}}; {{@Email}}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "{{@DerectionFromPrefix}}; {{@DerectionToPrefix}}";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "{{@DerectionFrom}}; {{@DerectionTo}}";
            // 
            // buttonCreateSend
            // 
            this.buttonCreateSend.Location = new System.Drawing.Point(400, 358);
            this.buttonCreateSend.Name = "buttonCreateSend";
            this.buttonCreateSend.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateSend.TabIndex = 10;
            this.buttonCreateSend.Text = "Создать";
            this.buttonCreateSend.UseVisualStyleBackColor = true;
            // 
            // richTextBoxEmail
            // 
            this.richTextBoxEmail.Location = new System.Drawing.Point(14, 158);
            this.richTextBoxEmail.Name = "richTextBoxEmail";
            this.richTextBoxEmail.Size = new System.Drawing.Size(461, 194);
            this.richTextBoxEmail.TabIndex = 9;
            this.richTextBoxEmail.Text = "";
            // 
            // labelEmeil
            // 
            this.labelEmeil.AutoSize = true;
            this.labelEmeil.Location = new System.Drawing.Point(11, 142);
            this.labelEmeil.Name = "labelEmeil";
            this.labelEmeil.Size = new System.Drawing.Size(81, 13);
            this.labelEmeil.TabIndex = 8;
            this.labelEmeil.Text = "Текст письма:";
            // 
            // textBoxToIndex
            // 
            this.textBoxToIndex.Enabled = false;
            this.textBoxToIndex.Location = new System.Drawing.Point(235, 62);
            this.textBoxToIndex.Name = "textBoxToIndex";
            this.textBoxToIndex.Size = new System.Drawing.Size(35, 20);
            this.textBoxToIndex.TabIndex = 7;
            // 
            // labelToIndex
            // 
            this.labelToIndex.AutoSize = true;
            this.labelToIndex.Location = new System.Drawing.Point(191, 65);
            this.labelToIndex.Name = "labelToIndex";
            this.labelToIndex.Size = new System.Drawing.Size(48, 13);
            this.labelToIndex.TabIndex = 6;
            this.labelToIndex.Text = "Индекс:";
            // 
            // textBoxFromIndex
            // 
            this.textBoxFromIndex.Enabled = false;
            this.textBoxFromIndex.Location = new System.Drawing.Point(235, 28);
            this.textBoxFromIndex.Name = "textBoxFromIndex";
            this.textBoxFromIndex.Size = new System.Drawing.Size(35, 20);
            this.textBoxFromIndex.TabIndex = 5;
            // 
            // labelFromIndex
            // 
            this.labelFromIndex.AutoSize = true;
            this.labelFromIndex.Location = new System.Drawing.Point(191, 31);
            this.labelFromIndex.Name = "labelFromIndex";
            this.labelFromIndex.Size = new System.Drawing.Size(48, 13);
            this.labelFromIndex.TabIndex = 4;
            this.labelFromIndex.Text = "Индекс:";
            // 
            // comboBoxToCountry
            // 
            this.comboBoxToCountry.FormattingEnabled = true;
            this.comboBoxToCountry.Location = new System.Drawing.Point(54, 62);
            this.comboBoxToCountry.Name = "comboBoxToCountry";
            this.comboBoxToCountry.Size = new System.Drawing.Size(121, 21);
            this.comboBoxToCountry.TabIndex = 3;
            // 
            // labelToCountry
            // 
            this.labelToCountry.AutoSize = true;
            this.labelToCountry.Location = new System.Drawing.Point(11, 65);
            this.labelToCountry.Name = "labelToCountry";
            this.labelToCountry.Size = new System.Drawing.Size(34, 13);
            this.labelToCountry.TabIndex = 2;
            this.labelToCountry.Text = "Куда:";
            // 
            // comboBoxFromCountry
            // 
            this.comboBoxFromCountry.FormattingEnabled = true;
            this.comboBoxFromCountry.Location = new System.Drawing.Point(54, 28);
            this.comboBoxFromCountry.Name = "comboBoxFromCountry";
            this.comboBoxFromCountry.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFromCountry.TabIndex = 1;
            // 
            // labelFromCountry
            // 
            this.labelFromCountry.AutoSize = true;
            this.labelFromCountry.Location = new System.Drawing.Point(11, 31);
            this.labelFromCountry.Name = "labelFromCountry";
            this.labelFromCountry.Size = new System.Drawing.Size(46, 13);
            this.labelFromCountry.TabIndex = 0;
            this.labelFromCountry.Text = "Откудо:";
            // 
            // groupBoxSender
            // 
            this.groupBoxSender.Controls.Add(this.buttonDelete);
            this.groupBoxSender.Controls.Add(this.buttonStop);
            this.groupBoxSender.Controls.Add(this.buttonStartSend);
            this.groupBoxSender.Controls.Add(this.dataGridViewSends);
            this.groupBoxSender.Location = new System.Drawing.Point(506, 13);
            this.groupBoxSender.Name = "groupBoxSender";
            this.groupBoxSender.Size = new System.Drawing.Size(659, 500);
            this.groupBoxSender.TabIndex = 1;
            this.groupBoxSender.TabStop = false;
            this.groupBoxSender.Text = "Рассылка";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(7, 457);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(109, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Удалить все";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(476, 456);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Стоп";
            this.buttonStop.UseVisualStyleBackColor = true;
            // 
            // buttonStartSend
            // 
            this.buttonStartSend.Location = new System.Drawing.Point(395, 456);
            this.buttonStartSend.Name = "buttonStartSend";
            this.buttonStartSend.Size = new System.Drawing.Size(75, 23);
            this.buttonStartSend.TabIndex = 1;
            this.buttonStartSend.Text = "Запуск";
            this.buttonStartSend.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSends
            // 
            this.dataGridViewSends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSends.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Email,
            this.Subject,
            this.Text,
            this.Status,
            this.IsPost});
            this.dataGridViewSends.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewSends.Name = "dataGridViewSends";
            this.dataGridViewSends.Size = new System.Drawing.Size(644, 430);
            this.dataGridViewSends.TabIndex = 0;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.Width = 150;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Subject";
            this.Subject.Name = "Subject";
            // 
            // Text
            // 
            this.Text.HeaderText = "Text";
            this.Text.Name = "Text";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // IsPost
            // 
            this.IsPost.HeaderText = "IsPost";
            this.IsPost.Name = "IsPost";
            this.IsPost.Width = 50;
            // 
            // DerectionSenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 524);
            this.Controls.Add(this.groupBoxSender);
            this.Controls.Add(this.groupBoxParams);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.groupBoxParams.ResumeLayout(false);
            this.groupBoxParams.PerformLayout();
            this.groupBoxSender.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSends)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxParams;
        private System.Windows.Forms.Label labelFromIndex;
        private System.Windows.Forms.ComboBox comboBoxToCountry;
        private System.Windows.Forms.Label labelToCountry;
        private System.Windows.Forms.ComboBox comboBoxFromCountry;
        private System.Windows.Forms.Label labelFromCountry;
        private System.Windows.Forms.TextBox textBoxToIndex;
        private System.Windows.Forms.Label labelToIndex;
        private System.Windows.Forms.TextBox textBoxFromIndex;
        private System.Windows.Forms.Button buttonCreateSend;
        private System.Windows.Forms.RichTextBox richTextBoxEmail;
        private System.Windows.Forms.Label labelEmeil;
        private System.Windows.Forms.GroupBox groupBoxSender;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStartSend;
        private System.Windows.Forms.DataGridView dataGridViewSends;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxEmailFrom;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Text;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPost;
    }
}

