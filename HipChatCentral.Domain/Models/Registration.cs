using System;
using System.ComponentModel.DataAnnotations;

namespace HipChatCentral.Domain.Models
{
    public class Registration
    {
        [Key]
        public Int32 Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }        
    }
}