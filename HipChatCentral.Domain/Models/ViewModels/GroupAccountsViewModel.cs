using System;
using System.Collections.Generic;

namespace HipChatCentral.Domain.Models.ViewModels
{
    public class GroupAccountsViewModel
    {
        public Int32 RegistrationId { get; set; }
        public IList<GroupAccount> GroupAccounts { get; set; }
    }
}