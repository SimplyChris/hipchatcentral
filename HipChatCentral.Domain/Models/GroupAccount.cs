using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HipChatCentral.Domain.Models.Base;

namespace HipChatCentral.Domain.Models
{
    public class GroupAccount : GroupAccountBase
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 RegistrationId { get; set; }
        public virtual ICollection<HipChatApiKey> ApiKeys { get; set; }
    }
}