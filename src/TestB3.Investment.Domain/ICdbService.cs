using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestB3.Investment.Domain
{
    public interface ICdbService
    {
        Task<Investment> CalculateInvestment(decimal startingMoney, int month);
    }
}
