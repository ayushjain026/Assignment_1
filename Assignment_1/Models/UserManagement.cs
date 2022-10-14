using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models
{
    public partial class UserManagement
    {
        [Key]
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; } = null!;
        public string? Company { get; set; }
        //public string State { get; set; } = null!;
        public string City { get; set; } = null!;
        public int ZipCode { get; set; }
        public string? Gender { get; set; }
        public DateTime Dob { get; set; }
        public short? AllowNotification { get; set; }


        //public Country Country { get; set; }
        public int CountryId { get; set; }
        //public State State { get; set; }
        public int StateId { get; set; }

        //public State states { get; set; }
        //public int StateId { get; set; }
    }
}
