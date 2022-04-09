using BankingSystem.AboutClient;
using BankingSystem.AllAccount;

namespace BankingSystem.FormClient
{
    
    public partial class FormClient : Form, IDataClient
    {
        private readonly DataClientPresenter dataClientPresenter;
        string IDataClient.HomeId 
        { 
            get
            {
                try
                {
                    if (comboBoxNature.SelectedItem.ToString() == "Счета")
                    {
                        string select = listBoxInfo.SelectedItem.ToString();
                        return select.Substring(select.Length - 41, 41);
                    }
                    else { return ""; }
                }
                catch { return ""; }
            } 
        }
        string IDataClient.AlienId
        { 
            get
            {
                return textBoxAccount.Text;
            }
            set
            {
                textBoxAccount.Text = value;
            }
        }
        string IDataClient.Sum
        { 
            get
            {
                return textBoxSum.Text;
            }
        }
        string IDataClient.Nature
        {
            get
            {
                try
                {
                    return comboBoxNature.SelectedItem.ToString();
                }
                catch (NullReferenceException) { return ""; }
            }
        }
        string? IDataClient.ToReg
        {
            get
            {
                try
                {
                    return comboBoxRequest.SelectedItem.ToString();
                }
                catch (NullReferenceException) { return null; }
            }
        }
        string? IDataClient.Currency
        {
            get
            {
                try
                {
                    return comboBoxCurrency.SelectedItem.ToString();
                }
                catch (NullReferenceException) { return null; }
            }
        }
        string? IDataClient.Month
        {
            get
            {
                try
                {
                    return comboBoxMonth.SelectedItem.ToString();
                }
                catch (NullReferenceException) { return null; }
            }
        }
        internal AccountPresenter AccountPresenter
        {
            get => default;
            set
            {
            }
        }

        public FormClient()
        {
            InitializeComponent();
        }
        public FormClient(string Bank, string id)
        {
            InitializeComponent();
            this.labelBank.Text = Bank;
            dataClientPresenter = new(new Bank(Bank), id);
        }

        private void buttonRequestAcc_Click(object sender, EventArgs e)
        {
            dataClientPresenter.SendToApprove(this);
        }
        private void comboBoxNature_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataClientPresenter.FillTheBox(listBoxInfo, this);
        }

        private void buttonAddSum_Click(object sender, EventArgs e)
        {
                dataClientPresenter.PlusSum(this);
                comboBoxNature_SelectedIndexChanged(comboBoxNature, EventArgs.Empty);
        }

        private void buttonTakeCash_Click(object sender, EventArgs e)
        {
            dataClientPresenter.MinusSum(this);
            comboBoxNature_SelectedIndexChanged(comboBoxNature, EventArgs.Empty);
        }

        private void listBoxInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string select = listBoxInfo.SelectedItem.ToString();
                Clipboard.SetText(select.Substring(select.Length - 41, 41));
            }
            catch (NullReferenceException){ MessageBox.Show("Выберите счет"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataClientPresenter.Transfer(this);
            comboBoxNature_SelectedIndexChanged(comboBoxNature, EventArgs.Empty);
        }

        private void buttonFreeze_Click(object sender, EventArgs e)
        {
            try
            {
                dataClientPresenter.Freeze(this);
                comboBoxNature_SelectedIndexChanged(comboBoxNature, EventArgs.Empty);
            }
            catch (NullReferenceException) { }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            dataClientPresenter.RemoveAcc(this);
            comboBoxNature_SelectedIndexChanged(comboBoxNature, EventArgs.Empty);
        }

        private void buttonRegComp_Click(object sender, EventArgs e)
        {
            FormCompanyReg formReg = new(dataClientPresenter.client, dataClientPresenter.Bank);
            formReg.ShowDialog();
        }

        private void buttonCompany_Click(object sender, EventArgs e)
        {
            FormCompany formComp = new(dataClientPresenter.client);
            formComp.ShowDialog();
        }
    }
}
