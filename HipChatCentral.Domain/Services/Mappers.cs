using HipChatCentral.Domain.Models;
using HipChatCentral.Domain.Models.ViewModels;

namespace HipChatCentral.Domain.Services
{
    public static class Mappers
    {
        public static EditApiKeyViewModel MapEditApiKeyModel(HipChatApiKey key)
        { 
            return new EditApiKeyViewModel()
            {
                ApiKey = key.ApiKey,
                Id = key.Id,
                Name = key.Name,
                IsSelected = false
            };
        }
    }
}