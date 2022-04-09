namespace BankingSystem
{
    partial class FormCompany
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
            this.comboBoxCompany = new System.Windows.Forms.ComboBox();
            this.textBoxAcc = new System.Windows.Forms.TextBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.textBoxMounth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddPay = new System.Windows.Forms.Button();
            this.buttonApprove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxCompany
            // 
            this.comboBoxCompany.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxCompany.FormattingEnabled = true;
            this.comboBoxCompany.Location = new System.Drawing.Point(185, 7);
            this.comboBoxCompany.Name = "comboBoxCompany";
            this.comboBoxCompany.Size = new System.Drawing.Size(235, 36);
            this.comboBoxCompany.TabIndex = 0;
            // 
            // textBoxAcc
            // 
            this.textBoxAcc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxAcc.Location = new System.Drawing.Point(185, 49);
            this.textBoxAcc.Name = "textBoxAcc";
            this.textBoxAcc.Size = new System.Drawing.Size(235, 34);
            this.textBoxAcc.TabIndex = 1;
            // 
            // textBoxSum
            // 
            this.textBoxSum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxSum.Location = new System.Drawing.Point(185, 89);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(235, 34);
            this.textBoxSum.TabIndex = 2;
            // 
            // textBoxMounth
            // 
            this.textBoxMounth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxMounth.Location = new System.Drawing.Point(185, 129);
            this.textBoxMounth.Name = "textBoxMounth";
            this.textBoxMounth.Size = new System.Drawing.Size(235, 34);
            this.textBoxMounth.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(44, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Предприятие";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(94, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Месяцы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(7, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Сумма зарплаты";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(126, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "Счет";
            // 
            // buttonAddPay
            // 
            this.buttonAddPay.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAddPay.Location = new System.Drawing.Point(12, 173);
            this.buttonAddPay.Name = "buttonAddPay";
            this.buttonAddPay.Size = new System.Drawing.Size(408, 58);
            this.buttonAddPay.TabIndex = 8;
            this.buttonAddPay.Text = "Добавить зарплату";
            this.buttonAddPay.UseVisualStyleBackColor = true;
            this.buttonAddPay.Click += new System.EventHandler(this.buttonAddPay_Click);
            // 
            // buttonApprove
            // 
            this.buttonApprove.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonApprove.Location = new System.Drawing.Point(12, 237);
            this.buttonApprove.Name = "buttonApprove";
            this.buttonApprove.Size = new System.Drawing.Size(408, 75);
            this.buttonApprove.TabIndex = 9;
            this.buttonApprove.Text = "Отправить запрос на\r\nзарплатный проект";
            this.buttonApprove.UseVisualStyleBackColor = true;
            this.buttonApprove.Click += new System.EventHandler(this.buttonApprove_Click);
            // 
            // FormCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 324);
            this.Controls.Add(this.buttonApprove);
            this.Controls.Add(this.buttonAddPay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMounth);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.textBoxAcc);
            this.Controls.Add(this.comboBoxCompany);
            this.Name = "FormCompany";
            this.Text = "FormCompany";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboBoxCompany;
        private TextBox textBoxAcc;
        private TextBox textBoxSum;
        private TextBox textBoxMounth;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button buttonAddPay;
        private Button buttonApprove;
    }
}