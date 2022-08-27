using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingMall.MVC.Models
{
    public class UserRegistration
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string EmailId { get; set; }
        [Required]
        public string PANNo { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(10, ErrorMessage = "Must be between 8 and 10 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(10, ErrorMessage = "Must be between 8 and 10 characters", MinimumLength = 8)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [NotMapped]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        public int UserRoleId { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
