
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TickChat.DataAccess.Entities;

namespace TickChat.DataAccess.Data.config;

public class ConversationParticipantConfig : IEntityTypeConfiguration<ConversationParticipant>
{
    public void Configure(EntityTypeBuilder<ConversationParticipant> conversationparticipent)
    {
        conversationparticipent.HasKey(cp => new { cp.ConversationId, cp.UserId });

        conversationparticipent.Property(cp => cp.Role)
              .HasMaxLength(20)
              .HasDefaultValue("Member");

        conversationparticipent.HasOne(cp => cp.Conversation)
              .WithMany(c => c.Participants)
              .HasForeignKey(cp => cp.ConversationId);

        conversationparticipent.HasOne(cp => cp.User)
              .WithMany(u => u.ConversationParticipants)
              .HasForeignKey(cp => cp.UserId);
    }
}
