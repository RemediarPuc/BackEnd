namespace RemediarAPI.Models
{
    public class EmissaoRelatorios
    {
        public int id { get; set; }
        public List<MedicamentoDescartado>? medicamentoDescartados {  get; set; }
        public Double? valorTotalMes { get; set; }
        public Double? valorTotalDoacao { get; set; }
    }
}
