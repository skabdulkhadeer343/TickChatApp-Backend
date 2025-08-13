namespace TickChat.DataAccess.Entities;

public class MessageStatus
{
    // Composite Key
    public Guid MessageId { get; set; }
    public Guid UserId { get; set; }
    
    // Status Tracking
    public bool IsDelivered { get; set; }
    public bool IsRead { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public DateTime? ReadAt { get; set; }
    
    // Navigation
    public Message Message { get; set; }
    public User User { get; set; }
}