using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TickChat.DataAccess.Entities;

public class File
{


    [Key]
    public Guid FileId { get; set; } = Guid.NewGuid();

    [Required]
    public Guid UserId { get; set; }

    public Guid? ConversationId { get; set; }

    [Required, MaxLength(255)]
    public string FileName { get; set; }

    [Required, MaxLength(100)]
    public string FileType { get; set; }

    public long FileSize { get; set; }

    [Required]
    public string FileUrl { get; set; }

    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    [ForeignKey(nameof(ConversationId))]
    public Conversation Conversation { get; set; }
}
