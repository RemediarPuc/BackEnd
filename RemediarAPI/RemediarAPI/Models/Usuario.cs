using System.Text.Json.Serialization;

namespace RemediarAPI.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string genero { get; set; }
        public int numPessoaCasa { get; set; }
        public string escolaridade { get; set; }
        public int faixaEtaria { get; set; }
        public double rendaFamiliar { get; set; }
        public string estado { get; set; }
        public string regiao { get; set; }
        public string cep { get; set; }
        public string rua { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoUsuario tipoUsuario { get; set; }
        public List<Pedido>? Pedidos { get; set; }
        public List<Doacao>? Doacoes { get; set; }
    }
}
