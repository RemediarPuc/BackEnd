namespace RemediarAPI.Models
{
    public class MedicamentoDescartado
    {
        public int id { get; set; }
        public DateTime dtDescarte { get; set; }
        public DateTime dtVencimento { get; set; }
        public int qtdDescartada { get; set; }
        public double valorDescartado { get; set; }
        public int medicamentoId { get; set; }
        public Medicamento? Medicamento { get; set; }
    }
}
