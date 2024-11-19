using System.ComponentModel.Design;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaboratoriumASPNET.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }

        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source = {DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ustawienia ról
            string ADMIN_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Id = ADMIN_ID,
                        Name = "admin",
                        NormalizedName = "ADMIN",
                        ConcurrencyStamp = ADMIN_ID
                    },
                    new IdentityRole
                    {
                        Id = USER_ID,
                        Name = "user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = USER_ID
                    }
                );

            // Utworzenie użytkowników
            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "Adam",
                NormalizedUserName = "ADAM",
                Email = "adam@wsei.edu.pl",
                NormalizedEmail = "ADAM@WSEI.EDU.PL",
                EmailConfirmed = true
            };

            var user = new IdentityUser
            {
                Id = USER_ID,
                UserName = "Ewa",
                NormalizedUserName = "EWA",
                Email = "ewa@wsei.edu.pl",
                NormalizedEmail = "EWA@WSEI.EDU.PL",
                EmailConfirmed = true
            };

            // Dodanie hasła dla użytkowników
            PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = hasher.HashPassword(admin, "1234!");
            user.PasswordHash = hasher.HashPassword(user, "5678!");

            modelBuilder.Entity<IdentityUser>().HasData(admin, user);

            // Dodanie organizacji z adresem
            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(o => o.Adress)
                .HasData(
                    new { OrganizationEntityId = 1, City = "Kraków", Street = "Św. Filipa 17" },
                    new { OrganizationEntityId = 2, City = "Warszawa", Street = "Wesoła 15" }
                );

            // Relacje między ContactEntity a OrganizationEntity
            modelBuilder.Entity<ContactEntity>()
                .HasOne<OrganizationEntity>(c => c.Organization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(c => c.OrganizationId);

            // Wstawienie danych organizacji
            modelBuilder.Entity<OrganizationEntity>()
                .HasData(
                    new OrganizationEntity
                    {
                        Id = 1,
                        Regon = "321321321",
                        Nip = "123456",
                        Name = "WSEI",
                    },
                    new OrganizationEntity
                    {
                        Id = 2,
                        Regon = "123123123",
                        Nip = "432432",
                        Name = "Famo",
                    }
                );

            // Wstawienie danych kontaktów
            modelBuilder.Entity<ContactEntity>()
                .HasData(
                    new ContactEntity
                    {
                        Id = 1,
                        FirstName = "Adam",
                        LastName = "Nowak",
                        Phone = "123123123",
                        DateOfBirth = new DateTime(1980, 1, 1),
                        Email = "ewa@wsei.edu.pl",
                        Created = DateTime.Now,
                        OrganizationId = 1
                    },
                    new ContactEntity
                    {
                        Id = 2,
                        FirstName = "Ola",
                        LastName = "Nowak",
                        Phone = "123123123",
                        DateOfBirth = new DateTime(2001, 1, 1),
                        Email = "ola@wsei.edu.pl",
                        Created = DateTime.Now,
                        OrganizationId = 2
                    }
                );
        }
    }
}
