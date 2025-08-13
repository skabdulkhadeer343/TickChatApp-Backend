
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TickChat.DataAccess.Entities;

namespace TickChat.DataAccess.Data.config;

public class MessageStatusConfig: IEntityTypeConfiguration<MessageStatus>
{
    public void Configure(EntityTypeBuilder<MessageStatus> messageStatus)
    {
        messageStatus.HasKey(ms => new { ms.MessageId, ms.UserId });

        messageStatus.HasOne(ms => ms.Message)
              .WithMany(m => m.Statuses)
              .HasForeignKey(ms => ms.MessageId);

        messageStatus.HasOne(ms => ms.User)
              .WithMany(u => u.MessageStatuses)
              .HasForeignKey(ms => ms.UserId);
    }
}
