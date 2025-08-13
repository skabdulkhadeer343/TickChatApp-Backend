using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TickChat.DataAccess.Entities;

public class ConversationParticipant
{

    [Key, Column(Order = 0)]
    public Guid ConversationId { get; set; }

    [Key, Column(Order = 1)]
    public Guid UserId { get; set; }

    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    // Role/Type (e.g., "Admin", "Member")
    [MaxLength(20)]
    public string Role { get; set; } = "Member";

    // Soft delete (if needed)
    public bool IsActive { get; set; } = true;

    [ForeignKey(nameof(ConversationId))]
    public Conversation Conversation { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}