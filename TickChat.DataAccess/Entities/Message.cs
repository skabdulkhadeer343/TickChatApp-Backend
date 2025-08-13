using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TickChat.DataAccess.Entities;

public class Message
{

    [Key]
    public Guid MessageId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid ConversationId { get; set; }

    [Required]
    public Guid SenderUserId { get; set; }

    public Guid? FileId { get; set; }

    [Required, MaxLength(20)]
    public string MessageType { get; set; } = "text";

    [MaxLength(1000)]
    public string Content { get; set; }

    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    public DateTime? EditedAt { get; set; }

    public bool IsDeleted { get; set; } = false;

    [ForeignKey(nameof(ConversationId))]
    public Conversation Conversation { get; set; }

    [ForeignKey(nameof(SenderUserId))]
    public User SenderUser { get; set; }

    [ForeignKey(nameof(FileId))]
    public File File { get; set; }
    public ICollection<MessageStatus> Statuses { get; set; }

}
