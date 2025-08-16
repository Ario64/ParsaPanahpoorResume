using Resume.Domain.Entity.Common;
using System.ComponentModel.DataAnnotations;

namespace Resume.Domain.ViewModels.Message;

public class MessageListViewModel: BaseEntity<long>
{
    public string Name { get; set; }

    public string Email { get; set; }

    public string Text { get; set; }
}