using System.ComponentModel.DataAnnotations;

namespace HipChatCentral.Domain.Models.Base
{
    public abstract class GroupAccountBase
    {
        [Display (Name = "Group Name")]
        public string GroupName { get; set; }
    }
}