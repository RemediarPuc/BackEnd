using System.Text.Json.Serialization;

namespace RemediarAPI.Models
{
    public class Doacao
    {
        public int id { get; set; }
        public string nomeMedicamento { get; set; }
        public int qtdCaixas { get; set; }
        public int qtdMg { get; set; }
        public DateTime dtValidade { get; set; }
        public DateTime dtRetirada { get; set; }
        public double valorDoacao { get; set; }
        public int usuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status statusDoacao { get; set; }
    }
}
