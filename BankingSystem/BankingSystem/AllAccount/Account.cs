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
        public string Currency { get; }

        public Account(string Id, string Sum, bool State, string Currency)
        {
            this.Id = Id;
            this.Sum = Sum;
            this.State = State;
            this.Currency = Currency;
        }

        public void AddMoney(Logs logs, string Num, bool sign, float revert = 1)
        {
            if (this.State)
            {
                try
                {
                    float sum = Convert.ToSingle(this.Sum);
                    float num = Convert.ToSingle(Num);
                    if (num != 0)
                    {
                        num = (float)Math.Round(num /= revert, 2);
                        if (num < 0) { num *= -1; }
                        if (sign == true)
                        {
                            sum = (float)Math.Round(sum += num, 2);
                        }
                        else if (sign == false && sum >= num)
                        {
                            sum = (float)Math.Round(sum -= num, 2);
                        }
                        else { MessageBox.Show("Слишком большая сумма"); }
                        this.Sum = Convert.ToString(sum);
                    }
                    else { MessageBox.Show("Введите корректную сумму"); }
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
