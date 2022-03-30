using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.AllAccount
{
    internal class Account
    {
        public string Id { get; set; }
        public string Sum { get; set; }
        public bool State { get; set; }

        public Account(string Id, string Sum, bool State)
        {
            this.Id = Id;
            this.Sum = Sum;
            this.State = State;
        }

        public void AddMoney(string Num)
        {
            if (this.State)
            {
                try
                {
                    float sum = Convert.ToSingle(this.Sum);
                    float num = Convert.ToSingle(Num);
                    if(num < 0) { num *= -1; }
                    sum += num;
                    this.Sum = Convert.ToString(sum);
                }
                catch { MessageBox.Show("Неверный ввод"); }
            }
            else { MessageBox.Show("Счет заморожен"); }
        }

        public void CreateId(string Id, int num, string Bank)
        {
            if(num < 10)
            {
                IdCase(Id, "000", num, Bank);
            }
            else if(num < 100)
            {
                IdCase(Id, "00", num, Bank);
            }
            else if(num < 1000)
            {
                IdCase(Id, "0", num, Bank);
            }
            else if(num < 10000)
            {
                IdCase(Id, "", num, Bank);
            }
        }

        private void IdCase(string Id, string zero, int num, string Bank)
        {
            this.Id = Id + zero + Convert.ToString(num) + Bank;
        }
    }
}
