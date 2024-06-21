namespace RemediarAPI.Models
{
    public class Medicamento
    {
        public int id { get; set; }
        public string nomeMedicamento { get; set; }
        public string unidade { get; set; }
        public int quantidade { get; set; }
        public DateTime dtVencimento { get; set; }
        public string descricao { get; set; }
        public double valor { get; set; }
    }
}
