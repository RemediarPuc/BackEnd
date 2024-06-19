namespace RemedirAPI.Models
{
    public class Endereco
    {
        public Endereco(string estado, string regiao, string cep, string rua, int numero, string bairro) {
            this.estado = estado;
            this.regiao = regiao;
            this.cep = cep;
            this.rua = rua;
            this.numero = numero;
            this.bairro = bairro;
        }
        public string estado { get; set; }
        public string regiao { get; set; }
        public string cep { get; set; }
        public string rua { get; set; }
        public int numero { get; set; }
        public string bairro { get; set; }
    }
}
