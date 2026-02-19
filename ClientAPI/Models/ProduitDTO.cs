using System.ComponentModel.DataAnnotations;

namespace ClientAPI.Models
{
    public class ProduitDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom ne doit pas dépasser 100 caractères.")]
        [RegularExpression(@"^[^<>]*$", ErrorMessage = "Les caractères < et > sont interdits.")]
        public string Nom { get; set; }
        [Range(0.01, 100000, ErrorMessage = "Le prix doit être positif.")]
        public decimal Prix { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Le stock doit être positif.")]
        public int Stock { get; set; }


    }
}
