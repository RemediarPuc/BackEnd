namespace RemediarAPI.Models
{
    public class Doacoes
    {
        public int id { get; set; }
        public string nomeMedicamento { get; set; }
        public int qtdCaixas { get; set; }
        public int qtdMg { get; set; }
        public DateTime dtValidade { get; set; }
        public string nomeDoador { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public DateTime dtRetirada { get; set; }
        public string horario { get; set; }
        public string status { get; set; }
        public DateTime data { get; set; }
        public DateTime dataRetirada { get; set; }
        public double valorDoacao { get; set; }
        public int usuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public Status statusDoacao { get; set; }
    }
}
