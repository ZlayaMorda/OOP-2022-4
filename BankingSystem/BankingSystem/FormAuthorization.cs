using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankingSystem.AboutClient;

namespace BankingSystem.Authorization
{
    internal partial class FormAuthorization : Form, IClient
    {
        public FormAuthorization()
        {
            InitializeComponent();
        }

        string? IClient.Surname
        {
            get
            {
                return textBoxSurname.Text;
            }
            set
            {
                textBoxSurname.Text = value;
            }
        }
        string? IClient.Name
        {
            get
            {
                return textBoxName.Text;
            }
            set
            {
                textBoxName.Text = value;
            }
        }
        string? IClient.PName
        {
            get
            {
                return textBoxPName.Text;
            }
            set
            {
                textBoxPName.Text = value;
            }
        }
        string? IClient.PhoneNumber
        {
            get
            {
                return textBoxPhone.Text;
            }
            set
            {
                textBoxPhone.Text = value;
            }
        }
        string? IClient.PasportNum
        {
            get
            {
                return textBoxPasport.Text;
            }
            set
            {
                textBoxPasport.Text = value;
            }
        }
        public string? LoginText
        {
            get
            {
                return textBoxEmail.Text;
            }
            set
            {
                textBoxEmail.Text = value;
            }
        }
        public string? PasswordText
        {
            get
            {
                return textBoxParole.Text;
            }
            set
            {
                textBoxParole.Text = value;
            }
        }
        public string? Bank
        {
            get
            {
                try
                {
                    return comboBoxBank.SelectedItem.ToString();
                }
                catch (NullReferenceException) { return null; }
            }
        }

        public string? Message
        {
            get
            {
                return labelMessage.Text;
            }
            set
            {
                labelMessage.Text = value;
            }
        }

        public string? Member => throw new NotImplementedException();

        private void button1_Click(object sender, EventArgs e)
        {
            ClientPresenter presenter = new(this);
            if(presenter.SendToApprove())
            {
                textBoxParole.Clear();
                textBoxEmail.Clear();
                textBoxName.Clear();
                textBoxParole.Clear();
                textBoxPhone.Clear();
                textBoxPName.Clear();
                textBoxSurname.Clear();
                textBoxPasport.Clear();
            }
        }
    }
}
