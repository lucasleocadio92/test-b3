using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestB3.Core.DomainObjects;

namespace TestB3.Investment.Domain
{
    public class Investment : Entity, IAggregateRoot
    {
        public decimal StartingMoney { get; private set; }
        public int Month { get; private set; }
        public decimal GrossFinalMoney { get; private set; }
        public decimal NetFinalMoney { get; private set; }

        public Investment(decimal startingMoney, int month)
        {
            StartingMoney = startingMoney;
            Month = month;

            Validate();
        }

        public void SetGrossFinalMoney(decimal grossFinalMoney)
        {
            Validations.ValidateIfLessThan(grossFinalMoney, 1, "O campo GrossFinalMoney não pode se menor igual a 0");
            
            GrossFinalMoney = grossFinalMoney;
        }

        public void SeNetFinalMoneye(decimal netFinalMoney)
        {
            Validations.ValidateIfLessThan(netFinalMoney, 1, "O campo NetFinalMoney não pode se menor igual a 0");
            Validations.ValidateIfLessThan(GrossFinalMoney, netFinalMoney, "O campo GrossFinalMoney não pode se menor igual o campo NetFinalMoney");
            NetFinalMoney = netFinalMoney;
        }

        public void Validate()
        {
            Validations.ValidateIfLessThan(StartingMoney, 1, "O campo StartingMoney não pode se menor igual a 0");
            Validations.ValidateIfLessThan(Month, 1, "O campo Month não pode se menor igual a 0");
        }
    }
}
