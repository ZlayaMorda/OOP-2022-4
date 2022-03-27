using BankingSystem.UserAut;
using BankingSystem.BankManagement;

namespace BankingSystem.FormManagement
{
    public partial class FormManagement : Form, IUser
    {
        public FormManagement()
        {
            InitializeComponent();
        }
        public FormManagement(string bank, bool admin)
        {
            InitializeComponent();
            this.labelBank.Text = bank;
            this.labelLogin.Visible = admin;
            this.labelMessage.Visible = admin;
            this.labelPassword.Visible = admin;
            this.textBoxLogin.Visible = admin;
            this.textBoxPassword.Visible = admin;
            this.buttonAdd.Visible = admin;
            this.labelUser.Visible = admin;
            this.comboBoxUser.Visible = admin;
        }

        string IUser.LoginText
        {
            get
            {
                return textBoxLogin.Text;
            }
            set
            {
                textBoxLogin.Text = value;
            }
        }
        string IUser.PasswordText
        {
            get
            {
                return textBoxPassword.Text;
            }
            set
            {
                textBoxPassword.Text = value;
            }
        }
        string IUser.Message
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

        string IUser.Bank
        {
            get
            {
                try
                {
                    return labelBank.Text;
                }
                catch (NullReferenceException) { return null; }
            }
        }
        string IUser.Member
        {
            get
            {
                try
                {
                    return comboBoxUser.SelectedItem.ToString();
                }
                catch (NullReferenceException) { return null; }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            UserPresenter presenter = new(this);
            presenter.AddManager(comboBoxUser.SelectedItem.ToString());

        }
    }
}
