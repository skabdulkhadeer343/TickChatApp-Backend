using System.ComponentModel.DataAnnotations;

namespace TickChat.DataAccess.Entities;

public class Conversation
{
    [Key]
    public Guid ConversationId { get; set; } = Guid.NewGuid();

    public bool IsGroup { get; set; }
    public string GroupName { get; set; } = string.Empty;
    public string GroupPhotoUrl { get; set; } = string.Empty;

    // Timestamps
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastMessageAt { get; set; }

    // Soft delete
    public bool IsArchived { get; set; } = false;

    // Audit
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Guid UpdatedBy { get; set; }

    // Navigation Properties
    public ICollection<ConversationParticipant>? Participants { get; set; }
    public ICollection<Message>? Messages { get; set; }
    public ICollection<File>? Files { get; set; }
}