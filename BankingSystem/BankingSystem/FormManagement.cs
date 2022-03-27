using BankingSystem.UserAut;
using BankingSystem.BankManagement;

namespace BankingSystem.FormManagement
{
    public partial class FormManagement : Form, IUser
    {
        Operator oper;
        Manager manager;
        string id;
        public FormManagement()
        {
            InitializeComponent();
        }
        public FormManagement(string bank, string manag)
        {
            InitializeComponent();
            this.labelBank.Text = bank;
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
                id = manag;
                if (manag == "1111")
                {
                    oper = new Operator("", "", manag, bank);
                }    
                else
                {
                    manager = new Manager("", "", manag, bank);
                }
            }
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

        private void comboBoxNature_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            if(id == "2222" && comboBoxNature.SelectedItem.ToString() == "Заявки на авторизацию")
            {
                manager.GetClientsData();
                foreach(var key in manager.ClientsDict.Keys)
                {
                    listBoxInfo.Items.Add(manager.GetClient(key));
                }
            }
        }

        private void buttonApprove_Click(object sender, EventArgs e)
        {
            if (id == "2222" && listBoxInfo.SelectedIndices != null)
            {
                foreach (int num in listBoxInfo.SelectedIndices)
                {
                    manager.AddClient(listBoxInfo.Items[num].ToString().Substring(0,36));
                }
                manager.SendBack();
                comboBoxNature_SelectedIndexChanged(comboBoxNature, EventArgs.Empty);
            }
        }

        private void buttonRejection_Click(object sender, EventArgs e)
        {
            if (id == "2222" && listBoxInfo.SelectedIndices != null)
            {
                foreach (int num in listBoxInfo.SelectedIndices)
                {
                    manager.RemoveClient(listBoxInfo.Items[num].ToString().Substring(0, 36));
                }
                manager.SendBack();
                comboBoxNature_SelectedIndexChanged(comboBoxNature, EventArgs.Empty);
            }
        }
    }
}
