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
    public partial class Authorization : Form, IClient
    {
        public Authorization()
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
        string? IClient.Email
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

        string? IClient.ClientBank
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
