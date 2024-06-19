using System.ComponentModel.DataAnnotations;

namespace RemediarAPI.Models{
    public class ItemEstoque{
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomeItem { get; set; }
        [Required]
        public DateTime DataVencimento { get; set; }
        [Required]
        public int? Quantidade { get; set; }
    }
}