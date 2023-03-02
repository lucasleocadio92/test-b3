using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestB3.Investment.Domain
{
    public class CdbService : ICdbService
    {
        public static decimal CDI => 1.08m; //108%
        public static decimal TB => 0.009m; //0,9%

        public async Task<Investment> CalculateInvestment(decimal startingMoney, int month)
        {
            var investment = new Investment(startingMoney, month);

            for (int i = 1; i <= month; i++)
            {
                investment.SetGrossFinalMoney(startingMoney * (1 + CDI * TB)); 

                startingMoney = investment.GrossFinalMoney;
            }

            var taxIR = CalculateIR(investment.StartingMoney, investment.GrossFinalMoney, month);

            investment.SeNetFinalMoneye(investment.GrossFinalMoney - taxIR);

            return investment;
        }

        private decimal CalculateIR(decimal startingMoney, decimal grossFinalMoney, int month) 
        {
            var tax = 15m;

            if (month <= 6)
                tax = 22.5m;
            else if (month <= 12)
                tax = 20m;
            else if (month <= 24)
                tax = 17.5m;

            return (grossFinalMoney - startingMoney) * tax / 100;
        }
    }
}
