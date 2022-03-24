using UserAut;

namespace BankingSystem.Login
{
    public partial class Form1 : Form, IUser
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

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            UserPresenter presenter = new (this);
            presenter.FindUser();

        }

        private void buttonAuthorization_Click(object sender, EventArgs e)
        {
            //UserPresenter presenter = new(this);
            //presenter.AddUser();
            Authorization.Authorization f = new();
            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}