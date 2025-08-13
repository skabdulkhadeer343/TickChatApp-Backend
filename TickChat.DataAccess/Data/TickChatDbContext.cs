
using Microsoft.EntityFrameworkCore;
using TickChat.DataAccess.Data.config;
using TickChat.DataAccess.Entities;
using File = TickChat.DataAccess.Entities.File;

namespace TickChat.DataAccess.Data;

public class TickChatDbContext : DbContext
{
    public TickChatDbContext(DbContextOptions<TickChatDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    public DbSet<ConversationParticipant> ConversationParticipants { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<MessageStatus> MessageStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfig());
        modelBuilder.ApplyConfiguration(new ConversationConfig());
        modelBuilder.ApplyConfiguration(new ConversationParticipantConfig());
        modelBuilder.ApplyConfiguration(new FileConfig());
        modelBuilder.ApplyConfiguration(new MessageConfig());
        modelBuilder.ApplyConfiguration(new MessageStatusConfig());

        base.OnModelCreating(modelBuilder);
    }
}