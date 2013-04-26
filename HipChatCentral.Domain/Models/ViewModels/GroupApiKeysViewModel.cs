using System;
using System.Collections.Generic;

namespace HipChatCentral.Domain.Models.ViewModels
{
    public class GroupApiKeysViewModel
    {
        public Int32 GroupId { get; set; }
        public IList<ApiKeyListViewModel> ApiKeys { get; set; }
    }
}