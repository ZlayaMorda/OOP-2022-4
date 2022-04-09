namespace BankingSystem.FormManagement
{
    partial class FormManagement
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
            this.labelBank = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxNature = new System.Windows.Forms.ComboBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonApprove = new System.Windows.Forms.Button();
            this.buttonRejection = new System.Windows.Forms.Button();
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelBank
            // 
            this.labelBank.AutoSize = true;
            this.labelBank.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBank.Location = new System.Drawing.Point(3, 4);
            this.labelBank.Name = "labelBank";
            this.labelBank.Size = new System.Drawing.Size(63, 31);
            this.labelBank.TabIndex = 0;
            this.labelBank.Text = "Bank";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPassword.Location = new System.Drawing.Point(149, 107);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(217, 34);
            this.textBoxPassword.TabIndex = 7;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxLogin.Location = new System.Drawing.Point(149, 63);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(217, 34);
            this.textBoxLogin.TabIndex = 6;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPassword.Location = new System.Drawing.Point(63, 107);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(81, 28);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "Пароль";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLogin.Location = new System.Drawing.Point(75, 66);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(69, 28);
            this.labelLogin.TabIndex = 4;
            this.labelLogin.Text = "Логин";
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Items.AddRange(new object[] {
            "Оператор",
            "Менеджер"});
            this.comboBoxUser.Location = new System.Drawing.Point(150, 147);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(216, 36);
            this.comboBoxUser.TabIndex = 12;
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelUser.Location = new System.Drawing.Point(4, 150);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(140, 28);
            this.labelUser.TabIndex = 11;
            this.labelUser.Text = "Пользователь";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd.Location = new System.Drawing.Point(150, 202);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(216, 73);
            this.buttonAdd.TabIndex = 14;
            this.buttonAdd.Text = "Добавить\r\nв систему";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // comboBoxNature
            // 
            this.comboBoxNature.FormattingEnabled = true;
            this.comboBoxNature.Items.AddRange(new object[] {
            "Заявки на авторизацию",
            "Заявки на открытие счета",
            "Заявки на выдачу кредитов",
            "Заявки на регистрацию предприятия",
            "Заявки на зарплатный проект",
            "Логи движений по счетам",
            "Логи регистрации"});
            this.comboBoxNature.Location = new System.Drawing.Point(404, 12);
            this.comboBoxNature.Name = "comboBoxNature";
            this.comboBoxNature.Size = new System.Drawing.Size(432, 28);
            this.comboBoxNature.TabIndex = 15;
            this.comboBoxNature.SelectedIndexChanged += new System.EventHandler(this.ComboBoxNature_SelectedIndexChanged);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMessage.Location = new System.Drawing.Point(75, 294);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 31);
            this.labelMessage.TabIndex = 16;
            // 
            // buttonApprove
            // 
            this.buttonApprove.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonApprove.Location = new System.Drawing.Point(642, 421);
            this.buttonApprove.Name = "buttonApprove";
            this.buttonApprove.Size = new System.Drawing.Size(194, 70);
            this.buttonApprove.TabIndex = 17;
            this.buttonApprove.Text = "Принять";
            this.buttonApprove.UseVisualStyleBackColor = true;
            this.buttonApprove.Click += new System.EventHandler(this.ButtonApprove_Click);
            // 
            // buttonRejection
            // 
            this.buttonRejection.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRejection.Location = new System.Drawing.Point(404, 421);
            this.buttonRejection.Name = "buttonRejection";
            this.buttonRejection.Size = new System.Drawing.Size(194, 70);
            this.buttonRejection.TabIndex = 18;
            this.buttonRejection.Text = "Отказать";
            this.buttonRejection.UseVisualStyleBackColor = true;
            this.buttonRejection.Click += new System.EventHandler(this.ButtonRejection_Click);
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.HorizontalScrollbar = true;
            this.listBoxInfo.ItemHeight = 20;
            this.listBoxInfo.Location = new System.Drawing.Point(404, 57);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxInfo.Size = new System.Drawing.Size(432, 344);
            this.listBoxInfo.TabIndex = 19;
            // 
            // FormManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 503);
            this.Controls.Add(this.listBoxInfo);
            this.Controls.Add(this.buttonRejection);
            this.Controls.Add(this.buttonApprove);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.comboBoxNature);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.comboBoxUser);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.labelBank);
            this.Name = "FormManagement";
            this.Text = "FormManagement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelBank;
        private TextBox textBoxPassword;
        private TextBox textBoxLogin;
        private Label labelPassword;
        private Label labelLogin;
        private ComboBox comboBoxUser;
        private Label labelUser;
        private Button buttonAdd;
        private ComboBox comboBoxNature;
        private Label labelMessage;
        private Button buttonApprove;
        private Button buttonRejection;
        private ListBox listBoxInfo;
    }
}