using System;
using System.Collections.Generic;

namespace Assignment_1.Models
{
    public partial class UserManagement
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; } = null!;
        public string? Company { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public int ZipCode { get; set; }
        public string? Gender { get; set; }
        public DateTime Dob { get; set; }
        public short? AllowNotification { get; set; }
    }
}
