using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment_1.Models
{
    public partial class assignment1Context : DbContext
    {
        public assignment1Context(DbContextOptions<assignment1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<UserManagement> UserManagements { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }

    }
}
