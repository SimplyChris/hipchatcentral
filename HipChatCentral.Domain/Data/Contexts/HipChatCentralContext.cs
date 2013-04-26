using System.Data.Entity;
using HipChatCentral.Domain.Interfaces;
using HipChatCentral.Domain.Models;

namespace HipChatCentral.Domain.Data.Contexts
{
    public class HipChatCentralContext : DbContext, IHipChatCentralContext
    {
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<GroupAccount> GroupAccounts { get; set; }
        public DbSet<HipChatApiKey> ApiKeys { get; set; } 
        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}