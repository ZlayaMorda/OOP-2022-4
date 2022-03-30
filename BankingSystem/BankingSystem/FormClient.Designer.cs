﻿namespace BankingSystem.FormClient
{
    partial class FormClient
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
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.labelClient = new System.Windows.Forms.Label();
            this.comboBoxNature = new System.Windows.Forms.ComboBox();
            this.buttonRequestAcc = new System.Windows.Forms.Button();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.labelSum = new System.Windows.Forms.Label();
            this.buttonTakeCash = new System.Windows.Forms.Button();
            this.textBoxAccount = new System.Windows.Forms.TextBox();
            this.labelAccount = new System.Windows.Forms.Label();
            this.buttonAddSum = new System.Windows.Forms.Button();
            this.buttonFreeze = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelBank
            // 
            this.labelBank.AutoSize = true;
            this.labelBank.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBank.Location = new System.Drawing.Point(10, 9);
            this.labelBank.Name = "labelBank";
            this.labelBank.Size = new System.Drawing.Size(63, 31);
            this.labelBank.TabIndex = 0;
            this.labelBank.Text = "Bank";
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.HorizontalScrollbar = true;
            this.listBoxInfo.ItemHeight = 20;
            this.listBoxInfo.Location = new System.Drawing.Point(10, 56);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.Size = new System.Drawing.Size(319, 384);
            this.listBoxInfo.TabIndex = 1;
            this.listBoxInfo.SelectedIndexChanged += new System.EventHandler(this.listBoxInfo_SelectedIndexChanged);
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelClient.Location = new System.Drawing.Point(256, 9);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(73, 31);
            this.labelClient.TabIndex = 2;
            this.labelClient.Text = "Client";
            // 
            // comboBoxNature
            // 
            this.comboBoxNature.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxNature.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxNature.FormattingEnabled = true;
            this.comboBoxNature.Items.AddRange(new object[] {
            "Счета",
            "Кредиты"});
            this.comboBoxNature.Location = new System.Drawing.Point(336, 54);
            this.comboBoxNature.Name = "comboBoxNature";
            this.comboBoxNature.Size = new System.Drawing.Size(187, 36);
            this.comboBoxNature.TabIndex = 3;
            this.comboBoxNature.SelectedIndexChanged += new System.EventHandler(this.comboBoxNature_SelectedIndexChanged);
            // 
            // buttonRequestAcc
            // 
            this.buttonRequestAcc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonRequestAcc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRequestAcc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRequestAcc.Location = new System.Drawing.Point(335, 100);
            this.buttonRequestAcc.Name = "buttonRequestAcc";
            this.buttonRequestAcc.Size = new System.Drawing.Size(187, 68);
            this.buttonRequestAcc.TabIndex = 4;
            this.buttonRequestAcc.Text = "Отправить запрос\r\nна открыти счета";
            this.buttonRequestAcc.UseVisualStyleBackColor = false;
            this.buttonRequestAcc.Click += new System.EventHandler(this.buttonRequestAcc_Click);
            // 
            // textBoxSum
            // 
            this.textBoxSum.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxSum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSum.Location = new System.Drawing.Point(548, 56);
            this.textBoxSum.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(180, 34);
            this.textBoxSum.TabIndex = 8;
            this.textBoxSum.Text = "BYN";
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSum.Location = new System.Drawing.Point(548, 12);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(151, 28);
            this.labelSum.TabIndex = 9;
            this.labelSum.Text = "Введите сумму:";
            // 
            // buttonTakeCash
            // 
            this.buttonTakeCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonTakeCash.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonTakeCash.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonTakeCash.Location = new System.Drawing.Point(548, 100);
            this.buttonTakeCash.Name = "buttonTakeCash";
            this.buttonTakeCash.Size = new System.Drawing.Size(179, 68);
            this.buttonTakeCash.TabIndex = 10;
            this.buttonTakeCash.Text = "Снять наличные";
            this.buttonTakeCash.UseVisualStyleBackColor = false;
            this.buttonTakeCash.Click += new System.EventHandler(this.buttonTakeCash_Click);
            // 
            // textBoxAccount
            // 
            this.textBoxAccount.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxAccount.Location = new System.Drawing.Point(335, 278);
            this.textBoxAccount.Margin = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.textBoxAccount.Name = "textBoxAccount";
            this.textBoxAccount.Size = new System.Drawing.Size(392, 34);
            this.textBoxAccount.TabIndex = 11;
            // 
            // labelAccount
            // 
            this.labelAccount.AutoSize = true;
            this.labelAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAccount.Location = new System.Drawing.Point(335, 245);
            this.labelAccount.Name = "labelAccount";
            this.labelAccount.Size = new System.Drawing.Size(317, 28);
            this.labelAccount.TabIndex = 12;
            this.labelAccount.Text = "Введите на какой счет перевести:";
            // 
            // buttonAddSum
            // 
            this.buttonAddSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonAddSum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAddSum.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAddSum.Location = new System.Drawing.Point(548, 174);
            this.buttonAddSum.Name = "buttonAddSum";
            this.buttonAddSum.Size = new System.Drawing.Size(179, 68);
            this.buttonAddSum.TabIndex = 13;
            this.buttonAddSum.Text = "Добавить сумму";
            this.buttonAddSum.UseVisualStyleBackColor = false;
            this.buttonAddSum.Click += new System.EventHandler(this.buttonAddSum_Click);
            // 
            // buttonFreeze
            // 
            this.buttonFreeze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonFreeze.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonFreeze.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonFreeze.Location = new System.Drawing.Point(335, 174);
            this.buttonFreeze.Name = "buttonFreeze";
            this.buttonFreeze.Size = new System.Drawing.Size(187, 68);
            this.buttonFreeze.TabIndex = 14;
            this.buttonFreeze.Text = "Заморозить счет";
            this.buttonFreeze.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(336, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(391, 53);
            this.button1.TabIndex = 15;
            this.button1.Text = "Перевести на введенный счет";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.IndianRed;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(336, 386);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(186, 54);
            this.button2.TabIndex = 16;
            this.button2.Text = "Удалить счет";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(733, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonFreeze);
            this.Controls.Add(this.buttonAddSum);
            this.Controls.Add(this.labelAccount);
            this.Controls.Add(this.textBoxAccount);
            this.Controls.Add(this.buttonTakeCash);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.buttonRequestAcc);
            this.Controls.Add(this.comboBoxNature);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.listBoxInfo);
            this.Controls.Add(this.labelBank);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FormClient";
            this.Text = "FormClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelBank;
        private ListBox listBoxInfo;
        private Label labelClient;
        private ComboBox comboBoxNature;
        private Button buttonRequestAcc;
        private TextBox textBoxSum;
        private Label labelSum;
        private Button buttonTakeCash;
        private TextBox textBoxAccount;
        private Label labelAccount;
        private Button buttonAddSum;
        private Button buttonFreeze;
        private Button button1;
        private Button button2;
    }
}