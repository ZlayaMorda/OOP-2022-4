using BankingSystem.UserAut;

namespace BankingSystem.Login
{
    internal partial class Form1 : Form, IUser
    {
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
                    return comboBoxBank.SelectedItem.ToString();
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
                    if(textBoxLogin.Text.Contains("@"))
                    {
                        return "Клиент";
                    }
                    else
                    {
                        return "Администрация";
                    }
                    
                }
                catch (NullReferenceException) { return null; }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            UserPresenter presenter = new (this);
            presenter.OpenForm(presenter.FindUser());            
        }

        private void buttonAuthorization_Click(object sender, EventArgs e)
        {
            Authorization.FormAuthorization f = new();
            f.ShowDialog();
        }
    }
}