using System;
using Microsoft.EntityFrameworkCore;

namespace tatais.Models
{
	public class MobileContext : DbContext
    {
        public MobileContext(DbContextOptions<MobileContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Shifr> Shifr_tatais { get; set; } = null!;
        public DbSet<History_encrypted> History_Encrypteds { get; set; } = null!;
    }
}

