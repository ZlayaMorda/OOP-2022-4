using BankingSystem.AboutClient;
using BankingSystem.AllAccount;

namespace BankingSystem.FormClient
{
    
    public partial class FormClient : Form, IDataClient
    {
        DataClientPresenter dataClientPresenter;
        string IDataClient.HomeId 
        { 
            get
            {
                try
                {
                    if (comboBoxNature.SelectedItem.ToString() == "Счета")
                    {
                        return listBoxInfo.SelectedItem.ToString().Substring(13, 41);
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
            set
            {
                textBoxSum.Text = value;
            }
        }
        string IDataClient.Nature
        {
            get
            {
                if (comboBoxNature.SelectedItem.ToString() != null)
                {
                    return comboBoxNature.SelectedItem.ToString();
                }
                else { return ""; }
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
            Bank bank = new(Bank);
            dataClientPresenter = new(bank, id);
        }

        private void buttonRequestAcc_Click(object sender, EventArgs e)
        {
            AccountPresenter accPres = new();
            try
            {
                accPres.Send(dataClientPresenter.GetAcc(), dataClientPresenter.Bank.Name);
            }
            catch (NullReferenceException) { }
        }
        private void comboBoxNature_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();
            dataClientPresenter.FillTheBox(listBoxInfo, this);
        }

        private void buttonAddSum_Click(object sender, EventArgs e)
        {
                dataClientPresenter.AddSumToTheAcc(this);
                comboBoxNature_SelectedIndexChanged(comboBoxNature, EventArgs.Empty);
        }

        private void buttonTakeCash_Click(object sender, EventArgs e)
        {

        }

        private void listBoxInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
