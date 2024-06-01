namespace RemediarAPI.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public string nomeMedicamento { get; set; }
        public double dosagem { get; set; }
        public string unidade { get; set; }
        public int quantidade { get; set; }
        public bool usoContinuo { get; set; }
        public string endereco { get; set; }
        public string nomeUsuario { get; set; }
        public string telefone { get; set; }
        public DateTime data { get; set; }
        public DateTime dataRetirada { get; set; }
        public string status { get; set; }
        public double valorPedido { get; set; }
        public int usuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public Status statusPedido { get; set; }

    }
}
