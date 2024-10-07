using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TrackMyWork.Models;

namespace TrackMyWork.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // let's add the each model in order to perfomr crud application, don't forget this step !
        public DbSet<Client>Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Message> Messages { get; set; }
        
        public DbSet<Project> Projects { get; set; }

        public DbSet<TimeEntry> TimeEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            /** this has to be done because there was foreign key constraint error, how I fix the error then??  https://www.youtube.com/watch?v=RtwYM1j4HSo */
            base.OnModelCreating(Builder);
            
            Builder.Entity<Invoice>()
                .HasOne(i => i.Client)  
                .WithMany(c => c.Invoices)  
                .HasForeignKey(i => i.ClientId) 
                .OnDelete(DeleteBehavior.ClientSetNull);

         
            Builder.Entity<Invoice>()
                .HasOne(i => i.Project)  
                .WithMany(p => p.Invoices) 
                .HasForeignKey(i => i.ProjectId) 
                .OnDelete(DeleteBehavior.ClientSetNull);

             Builder.Entity<Project>()
               .HasOne(p => p.Client)
               .WithMany(c => c.Projects)
               .HasForeignKey(p => p.ClientId)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
       
    }
}
