namespace RemedirAPI.Models
{
    public class HistoricoDeDoador
    {
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Telefone { get; set; }
        public Double QtdTotalDoacao { get; set; }
        public Endereco? endereco { get; set; }
    }
}