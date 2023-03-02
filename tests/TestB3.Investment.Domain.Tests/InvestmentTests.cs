using TestB3.Core.DomainObjects;

namespace TestB3.Investment.Domain.Tests
{
    public class InvestmentTests
    {
        [Fact(DisplayName ="Adicionar Investimeto inválido")]
        [Trait("Investimento CDB","Investimento Tests")]
        public void AddInvestment_Validate_ReturnExceptions()
        {
            // Arrange & Act & Assert

            var ex = Assert.Throws<DomainException>(() =>
                new Investment(0, 12)
            );

            Assert.Equal("O campo StartingMoney não pode se menor igual a 0", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
               new Investment(100, 0)
           );

            Assert.Equal("O campo Month não pode se menor igual a 0", ex.Message);
        }

        [Fact(DisplayName = "Adicionar Investimeto valido")]
        [Trait("Investimento CDB", "Investimento Tests")]
        public void AddInvestment_Validate_Success()
        {
            // Arrange & Act & Assert

            var investment = new Investment(10000m, 12);

            Assert.Equal(10000m, investment.StartingMoney);
            Assert.Equal(12, investment.Month);
        }

        [Fact(DisplayName = "Calcular o Investimeto CDB")]
        [Trait("Investimento CDB", "Investimento Tests")]
        public async void AddInvestment_Calculate_Success()
        {
            // Arrange & Act & Assert

            var service = new CdbService();

            var investment = await service.CalculateInvestment(10000m, 12);

            Assert.Equal(11230.820949653057631841036240m, investment.GrossFinalMoney);
            Assert.Equal(10984.656759722446105472828992m, investment.NetFinalMoney);
            Assert.Equal(12, investment.Month);
        }
    }
}