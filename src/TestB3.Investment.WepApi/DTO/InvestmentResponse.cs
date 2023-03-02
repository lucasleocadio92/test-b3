using System.Text.Json.Serialization;

namespace TestB3.Investment.WepApi.DTO
{
    public class InvestmentResponse
    {
        [JsonPropertyName("valorAplicado")]
        public decimal StartingMoney { get; set; }
        [JsonPropertyName("qtdMeses")]
        public int Month { get; private set; }
        [JsonIgnore]
        public decimal GrossFinalMoney { get; set; }
        [JsonPropertyName("valorBruto")]
        public decimal GrossFinalMoneyRound { get { return decimal.Round(GrossFinalMoney, 2, MidpointRounding.AwayFromZero); } private set { } }
        [JsonIgnore]
        public decimal NetFinalMoney { get; set; }
        [JsonPropertyName("valorLiquido")]
        public decimal NetFinalMoneyRound { get { return decimal.Round(NetFinalMoney, 2, MidpointRounding.AwayFromZero); } private set { } }
    }
}
