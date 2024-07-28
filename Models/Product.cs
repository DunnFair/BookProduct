using System.ComponentModel.DataAnnotations;

namespace BookProduct.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }
    }
}
