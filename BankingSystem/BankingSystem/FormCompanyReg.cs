using BankingSystem.AboutClient;

namespace BankingSystem
{
    public partial class FormCompanyReg : Form, ICompany
    {
        private readonly CompanyPresenter companyPresenter;
        internal FormCompanyReg(Client cl, Bank Bank)
        {
            companyPresenter = new CompanyPresenter(Bank, cl);
            InitializeComponent();
        }

        string ICompany.CompanyType
        {
            get
            {
                return textBoxType.Text;
            }
            set
            {
                textBoxType.Text = value;
            }
        }
        string ICompany.LegalName
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
        string ICompany.PayersNumber
        {
            get
            {
                return textBoxPayersNum.Text;
            }
            set
            {
                textBoxPayersNum.Text = value;
            }
        }
        string ICompany.BankIdCode
        {
            get
            {
                return textBoxIdCode.Text;
            }
            set
            {
                textBoxIdCode.Text = value;
            }
        }
        string ICompany.JurAdress
        {
            get
            {
                return textBoxAdress.Text;
            }
            set
            {
                textBoxAdress.Text = value;
            }
        }

        private void buttonAuthorization_Click(object sender, EventArgs e)
        {
            companyPresenter.SendToReg(this);
        }
    }
}
