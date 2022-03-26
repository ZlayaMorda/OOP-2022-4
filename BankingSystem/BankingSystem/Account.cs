using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    internal class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sum { get; set; }
        public bool State { get; set; }

        public Account(string Id, string Name, string Sum, bool State)
        {
            this.Id = Id;
            this.Name = Name;
            this.Sum = Sum;
            this.State = State;
        }

        public void AddMoney(string Num)
        {
            try
            {
                float sum = Convert.ToSingle(this.Sum);
                float num = Convert.ToSingle(Num);
                sum += num;
                this.Sum = Convert.ToString(sum);
            }
            catch { MessageBox.Show("Неверный ввод"); }
        }

        public void CreateId(string Id, int num)
        {
            if(num < 10)
            {
                IdCase(Id, "000", num);
            }
            else if(num < 100)
            {
                IdCase(Id, "00", num);
            }
            else if(num < 1000)
            {
                IdCase(Id, "0", num);
            }
            else if(num < 10000)
            {
                IdCase(Id, "", num);
            }
            else { MessageBox.Show("Слишком много счетов"); }
        }

        private void IdCase(string Id, string zero, int num)
        {
            this.Id = Id + zero + Convert.ToString(num);
        }
    }
}
