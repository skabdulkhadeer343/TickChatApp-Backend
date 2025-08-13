using System.ComponentModel.DataAnnotations;

namespace TickChat.DataAccess.Entities;

public class User
{
    [Key]
    public Guid UserId { get; set; } = Guid.NewGuid();

    [Required, MaxLength(100)]
    public string Username { get; set; } = string.Empty;


    [Required, MaxLength(255), EmailAddress]
    public string Email { get; set; } = string.Empty;


    [Required]
    public string PasswordHash { get; set; } = string.Empty;


    [Required, MaxLength(100)]
    public string DisplayName { get; set; } = string.Empty;


    public string? ProfilePhotoUrl { get; set; }
    public string? StatusMessage { get; set; }

    [MaxLength(10)]
    public string Gender { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }
    public bool IsActive { get; set; } = true;

    // Audit
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Guid UpdatedBy { get; set; }

    // Navigation Properties
    public ICollection<ConversationParticipant>? ConversationParticipants { get; set; }
    public ICollection<Message>? SentMessages { get; set; }
    public ICollection<MessageStatus>? MessageStatuses { get; set; }
    public ICollection<File>? Files { get; set; }
}