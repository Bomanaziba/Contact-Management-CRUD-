using ContactManagement.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Repository
{
    public class EFDbContext : IdentityDbContext
    {
        
        public EFDbContext() : base("EFDbContext")
        {
            Database.SetInitializer<EFDbContext>(new CreateDatabaseIfNotExists<EFDbContext>());
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<UserAccount> UserAccounts { get; set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
    
}
