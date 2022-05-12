using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.AllAccount
{
    internal class Credit
    {
        public DateTime CreateDate { get; set; }
        public float Percent { get; set; }
        public string Data { get; set; }
        public string CreditSum { get; set; }
        public bool MinusOrPlus { get; set; }
        public string IdAcc { get; set; }


        public Credit(bool MinusOrPlus, float Percent, string Data, string CreditSum, string IdAcc, DateTime CreateDate = new DateTime()) 
        {
            if (CreateDate == DateTime.MinValue)
            {
                this.CreateDate = DateTime.Today;
            }
            else
            {
                this.CreateDate = CreateDate;
            }
            this.Percent = Percent;
            this.Data = Data;
            this.CreditSum = CreditSum;
            this.MinusOrPlus = MinusOrPlus;
            this.IdAcc = IdAcc;
        }

        public void ChangeSum(Dictionary<string, Account> AccountsDict)
        {
            DateTime temp = CreateDate;
            if (DateTime.Today == temp.AddMonths(1))
            {
                int TempData = Convert.ToInt32(Data);
                AccountsDict[IdAcc].AddMoney(CreditSum.ToString(), MinusOrPlus);
                TempData--;
                string data = TempData.ToString();
                this.CreateDate = DateTime.Today;
                this.Data = data;
            }
        }

        public void CreateSum()
        {
            int TempData = Convert.ToInt32(Data);
            float TempCreditSum = Convert.ToSingle(CreditSum);
            TempCreditSum /= TempData;
            TempCreditSum += TempCreditSum * Percent;
            TempCreditSum = (float)Math.Round(TempCreditSum, 2);
            this.CreditSum = TempCreditSum.ToString();
        }
    }
}
