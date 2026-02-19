using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InstawebAPI.Models
{
    public class Produit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du produit est obligatoire.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Le nom doit contenir entre 2 et 100 caractères.")]
        public string Nom { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le prix ne peut pas être négatif.")]
        public decimal Prix { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Le stock ne peut pas être négatif.")]
        public int Stock { get; set; }

        // constructeur
        public Produit()
        {

        }

        // constructeur
        public Produit(string nom, decimal prix, int stock)
        {
            ChangerNom(nom);
            ChangerPrix(prix);
            ChangerStock(stock);

        }

        // --- Règle métier : nom valide ---
        public void ChangerNom(string nom)
        {
            if (string.IsNullOrWhiteSpace(nom))
                throw new ArgumentException("Le nom du produit est obligatoire.");

            if (nom.Length < 2)
                throw new ArgumentException("Le nom doit contenir au moins 2 caractères.");

            Nom = nom;
        }

        // --- Règle métier : prix positif ---
        public void ChangerPrix(decimal prix)
        {
            if (prix < 0)
                throw new ArgumentException("Le prix ne peut pas être négatif.");

            Prix = prix;
        }

        // --- Règle métier : stock cohérent ---
        public void ChangerStock(int stock)
        {
            if (stock < 0)
                throw new ArgumentException("Le stock ne peut pas être négatif.");

            Stock = stock;
        }

        // --- Règle métier : décrémenter le stock ---
        public void RetirerDuStock(int quantite)
        {
            if (quantite <= 0)
                throw new ArgumentException("La quantité doit être positive.");

            if (quantite > Stock)
                throw new InvalidOperationException("Stock insuffisant.");

            Stock -= quantite;
        }

        // --- Règle métier : ajouter au stock ---
        public void AjouterAuStock(int quantite)
        {
            if (quantite <= 0)
            {
                throw new ArgumentException("La quantité doit être positive.");

            }
            Stock += quantite;
        }
    }
}
