namespace ShoppingMall.MVC.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRegistration> UserRegistrations { get; set; }
    }
}
