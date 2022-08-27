using System.ComponentModel.DataAnnotations;

namespace ShoppingMall.MVC.Models
{
    public class Mall
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string MallName { get; set; }
        [StringLength(50)]
        [Required]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        public int YearBuilt { get; set; }
    }
}
