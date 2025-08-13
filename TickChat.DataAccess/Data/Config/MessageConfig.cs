
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TickChat.DataAccess.Entities;

namespace TickChat.DataAccess.Data.config;

public class MessageConfig: IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> message)
    {
        message.HasKey(m => m.MessageId);

        message.Property(m => m.MessageType)
              .IsRequired()
              .HasMaxLength(20)
              .HasDefaultValue("text");

        message.Property(m => m.Content)
              .HasMaxLength(1000);

        message.HasOne(m => m.Conversation)
              .WithMany(c => c.Messages)
              .HasForeignKey(m => m.ConversationId);

        message.HasOne(m => m.SenderUser)
              .WithMany(u => u.SentMessages)
              .HasForeignKey(m => m.SenderUserId);

        message.HasOne(m => m.File)
              .WithMany()
              .HasForeignKey(m => m.FileId)
              .OnDelete(DeleteBehavior.SetNull);

        message.HasMany(m => m.Statuses)
              .WithOne(ms => ms.Message)
              .HasForeignKey(ms => ms.MessageId);
    }
}
