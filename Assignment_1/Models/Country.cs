namespace Assignment_1.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public virtual ICollection<UserManagement> UserManagements { get; set; }
    }
}
