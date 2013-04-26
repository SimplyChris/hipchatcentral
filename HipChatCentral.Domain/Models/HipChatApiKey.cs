using System;
using System.ComponentModel.DataAnnotations;
using HipChatCentral.Domain.Models.Base;

namespace HipChatCentral.Domain.Models
{
    public class HipChatApiKey : HipChatApiKeyBase 
    {
        [Key]
        public Int32 Id { get; set; }
    }
}