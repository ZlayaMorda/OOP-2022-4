using BankingSystem.UserAut;
using BankingSystem.BankManagement;

namespace BankingSystem.FormManagement
{
    public partial class FormManagement : Form, IUser
    {
        private readonly IAdmin? Administration;
        public FormManagement()
        {
            InitializeComponent();
        }
        public FormManagement(string bank, string manag)
        {
            InitializeComponent();
            this.labelBank.Text = bank;
            if (manag == "0000")
            {
                Administration = new Admin(manag, new Bank(bank));
            }
            if (manag == "1111" || manag == "2222")
            {
                this.labelLogin.Visible = false;
                this.labelMessage.Visible = false;
                this.labelPassword.Visible = false;
                this.textBoxLogin.Visible = false;
                this.textBoxPassword.Visible = false;
                this.buttonAdd.Visible = false;
                this.labelUser.Visible = false;
                this.comboBoxUser.Visible = false;
                
                if (manag == "1111")
                {
                    Administration = new Operator(manag, new Bank(bank));
                }
                else if (manag == "2222")
                {
                    Administration = new Manager(manag, new Bank(bank));
                }
            }
        }
        
        string? IUser.LoginText
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
        string? IUser.PasswordText
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
        string? IUser.Message
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

        string? IUser.Bank
        {
            get
            {
                try
                {
                    return labelBank.Text.ToString();
                }
                catch (NullReferenceException) { return null; }
            }
        }
        string? IUser.Member
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

        internal IAdmin IAdmin
        {
            get => default;
            set
            {
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Administration.Add(this);
        }

        private void ComboBoxNature_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            Administration.Show(listBoxInfo, comboBoxNature.SelectedItem.ToString());
        }

        private void ButtonApprove_Click(object sender, EventArgs e)
        {
            try
            {
                Administration.Approve(listBoxInfo, comboBoxNature.SelectedItem.ToString());
                ComboBoxNature_SelectedIndexChanged(comboBoxNature, EventArgs.Empty);
            }
            catch (NullReferenceException) { MessageBox.Show("Ничего не выбрано"); }
        }

        private void ButtonRejection_Click(object sender, EventArgs e)
        {
            try
            {
                Administration.Deny(listBoxInfo, comboBoxNature.SelectedItem.ToString());
                ComboBoxNature_SelectedIndexChanged(comboBoxNature, EventArgs.Empty);
            }
            catch (NullReferenceException) { MessageBox.Show("Ничего не выбрано"); }
        }
    }
}
