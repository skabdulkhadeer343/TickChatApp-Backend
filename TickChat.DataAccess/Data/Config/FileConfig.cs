using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace TickChat.DataAccess.Data.config;
using File = Entities.File;

public class FileConfig : IEntityTypeConfiguration<File>
{
    public void Configure(EntityTypeBuilder<File> file)
    {
        file.HasKey(f => f.FileId);

        file.Property(f => f.FileName)
              .IsRequired()
              .HasMaxLength(255);

        file.Property(f => f.FileType)
              .IsRequired()
              .HasMaxLength(100);

        file.Property(f => f.FileUrl)
              .IsRequired();

        file.HasOne(f => f.User)
              .WithMany(u => u.Files)
              .HasForeignKey(f => f.UserId);

        file.HasOne(f => f.Conversation)
              .WithMany(c => c.Files)
              .HasForeignKey(f => f.ConversationId)
              .OnDelete(DeleteBehavior.SetNull);
    }
}
