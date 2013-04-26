using System;

namespace HipChatCentral.Domain.Models.ViewModels
{
    public class CreateApiKeyViewModel
    {
        public GroupAccount groupAccount { get; set; }
        public HipChatApiKey apiKey { get; set; }
    }
}