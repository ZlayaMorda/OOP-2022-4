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
                    return comboBoxUser.SelectedItem.ToString();
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
            string? id = presenter.FindUser();
            MessageBox.Show(id);
            if ( id != null)
            {
                if(id.Substring(0,4) == "0000")
                {
                    MessageBox.Show(id);
                }
                else if(id.Substring(0,4) == "1111")
                {

                }
                else if( id.Substring(0,4) == "2222")
                {

                }
                else if( id.Substring(0,4) == "3333")
                {

                }
            }
        }

        private void buttonAuthorization_Click(object sender, EventArgs e)
        {
            //UserPresenter presenter = new(this);
            //presenter.AddAdmin();
            Authorization.Authorization f = new();
            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}