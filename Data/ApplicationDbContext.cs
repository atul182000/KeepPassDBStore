using System;
using System.Collections.Generic;
using System.Text;
using KeepPassDBStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KeepPassDBStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<KeepPassword> MyPasswords { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
