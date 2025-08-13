
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TickChat.DataAccess.Entities;

namespace TickChat.DataAccess.Data.config;

public class ConversationConfig : IEntityTypeConfiguration<Conversation>
{
    public void Configure(EntityTypeBuilder<Conversation> conversation)
    {
        conversation.HasKey(c => c.ConversationId);

        conversation.Property(c => c.GroupName)
              .HasMaxLength(255);

        conversation.HasMany(c => c.Participants)
              .WithOne(cp => cp.Conversation)
              .HasForeignKey(cp => cp.ConversationId);

        conversation.HasMany(c => c.Messages)
              .WithOne(m => m.Conversation)
              .HasForeignKey(m => m.ConversationId);

        conversation.HasMany(c => c.Files)
              .WithOne(f => f.Conversation)
              .HasForeignKey(f => f.ConversationId);
    }
}
