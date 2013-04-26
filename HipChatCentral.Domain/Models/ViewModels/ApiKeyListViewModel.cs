using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HipChatCentral.Domain.Models.Base;

namespace HipChatCentral.Domain.Models.ViewModels
{    
    public class ApiKeyListViewModel 
    {
        public Int32 GroupId { get; set; }
        public IList<EditApiKeyViewModel> KeyList { get; set; }        
    }    
}