using System.ComponentModel.DataAnnotations.Schema;

namespace HipChatCentral.Domain.Models.ViewModels
{
    [NotMapped]
    public class EditApiKeyViewModel : HipChatApiKey
    {
        public bool IsSelected { get; set; }
    }
}