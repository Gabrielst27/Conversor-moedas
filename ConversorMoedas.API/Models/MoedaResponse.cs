namespace ConversorMoedas.API.Models
{
    public class MoedaResponse
    {
        public decimal CotacaoCompra { get; set; }
        public decimal CotacaoVenda { get; set; }
        public string DataHoraCotacao { get; set; }
    }
}