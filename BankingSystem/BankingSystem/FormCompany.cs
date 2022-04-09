using BankingSystem.AboutClient;

namespace BankingSystem
{
    internal partial class FormCompany : Form, ISalary
    {
        CompanyPresenter companyPresenter;
        public FormCompany(Client cl)
        {
            companyPresenter = new(new Bank(cl.ClientBank), cl);
            InitializeComponent();
            foreach (var key in cl.CompanyDict.Keys)
            {
                comboBoxCompany.Items.Add(cl.CompanyDict[key].LegalName);
            }
        }
        string ISalary.Company 
        {
            get
            {
                try
                {
                    return comboBoxCompany.Text.ToString();
                }
                catch(NullReferenceException)
                {
                    return "";
                }
            }
        }
        string ISalary.AccId 
        {
            get
            {
                return textBoxAcc.Text.ToString();
            }
            set
            {
                textBoxAcc.Text = value;
            }
        }
        string ISalary.Sum 
        {
            get
            {
                return textBoxSum.Text.ToString();
            }
            set
            {
                textBoxSum.Text = value;
            }
        }
        string ISalary.Mounth 
        {
            get
            {
                return textBoxMounth.Text.ToString();
            }
            set
            {
                textBoxMounth.Text = value;
            }
        }

        private void buttonApprove_Click(object sender, EventArgs e)
        {
            companyPresenter.SendPayProject(this);
        }

        private void buttonAddPay_Click(object sender, EventArgs e)
        {
            companyPresenter.AddSalary(this);
        }
    }
}
