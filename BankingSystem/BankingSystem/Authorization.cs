namespace BankingSystem
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

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            UserPresenter presenter = new UserPresenter(this);
            presenter.FindUser();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}