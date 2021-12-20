using Aegis.AddressBook.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aegis.AddressBook.Data
{
    public class DataDBContext :DbContext
    {
        public DataDBContext(DbContextOptions<DataDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("AddressBook");

            modelBuilder.Entity<Contact>().ToTable("Contacts", "AddressBook");

            modelBuilder.Entity<AddressType>().ToTable("AddressTypes", "AddressBook");

            modelBuilder.Entity<Address>().ToTable("Addresses", "AddressBook");
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<AddressType> AddressTypes { get; set; }

        public DbSet<AddressType> Addresses { get; set; }
    }
}
