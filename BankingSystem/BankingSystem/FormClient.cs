using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingSystem.FormClient
{
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
        }
        public FormClient(string Bank, string Name)
        {
            InitializeComponent();
            this.labelBank.Text = Bank;
            this.labelClient.Text = Name;
        }
    }
}
