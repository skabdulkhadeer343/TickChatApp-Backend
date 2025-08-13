
using Microsoft.EntityFrameworkCore;
using TickChat.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TickChat.DataAccess.Data.config;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.HasKey(u => u.UserId);

        entity.Property(u => u.Username)
              .IsRequired()
              .HasMaxLength(100);

        entity.Property(u => u.Email)
              .IsRequired()
              .HasMaxLength(255);

        entity.Property(u => u.PasswordHash)
              .IsRequired();

        entity.Property(u => u.DisplayName)
              .HasMaxLength(100);

        entity.Property(u => u.Gender)
              .HasMaxLength(10);

        entity.HasMany(u => u.ConversationParticipants)
              .WithOne(cp => cp.User)
              .HasForeignKey(cp => cp.UserId);

        entity.HasMany(u => u.SentMessages)
              .WithOne(m => m.SenderUser)
              .HasForeignKey(m => m.SenderUserId);

        entity.HasMany(u => u.MessageStatuses)
              .WithOne(ms => ms.User)
              .HasForeignKey(ms => ms.UserId);

        entity.HasMany(u => u.Files)
              .WithOne(f => f.User)
              .HasForeignKey(f => f.UserId);
    }
}
