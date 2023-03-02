using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestB3.Investment.WepApi.DTO
{
    public class InvestmentRequest
    {
        [JsonPropertyName("valor")]
        [Range(1, Double.MaxValue, ErrorMessage = "O campo Valor não pode se menor igual a 0.")]
        public decimal StartingMoney { get;  set; }
        [JsonPropertyName("prazoMeses")]
        [Range(1, int.MaxValue, ErrorMessage = "O campo PrazoMeses não pode se menor igual a 0.")]
        public int Month { get; set; }
    }
}
