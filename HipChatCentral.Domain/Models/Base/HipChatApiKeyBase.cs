using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HipChatCentral.Domain.Models.Base
{
    public class HipChatApiKeyBase
    {
        public String Name { get; set; }
        public String ApiKey { get; set; }                        
    }
}