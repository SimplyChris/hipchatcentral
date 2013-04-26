using System.Data.Entity;
using HipChatCentral.Domain.Models;

namespace HipChatCentral.Domain.Interfaces
{
    public interface IHipChatCentralContext 
    {        
        void SaveChanges();
    }
}