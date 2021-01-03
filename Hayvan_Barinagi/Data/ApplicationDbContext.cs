using Hayvan_Barinagi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hayvan_Barinagi.Data
{
    public class ApplicationDbContext : IdentityDbContext<Kullanici>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hayvan> Hayvan { get; set; }
        public DbSet<Cins> Cins { get; set; }
        public DbSet<Tur> Tur { get; set; }
        public DbSet<Cinsiyet> Cinsiyet { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }


    }
}
