namespace Assignment_1.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<UserManagement> UserManagements { get; set;}

    }
}
