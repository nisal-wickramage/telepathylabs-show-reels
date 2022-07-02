using Microsoft.EntityFrameworkCore;
using TelepathyLabs.ShowReels.DataAccess;
using TelepathyLabs.ShowReels.Domain;

namespace TelepathyLabs.ShowReels.DataAccess;
public class TelepathyLabsDbContext: DbContext
{
    public TelepathyLabsDbContext(DbContextOptions<TelepathyLabsDbContext> options) : base(options)
    {
    }

    internal DbSet<ShowReelDbModel> ShowReels { get; set; }
    internal DbSet<VideoClip> VideoClips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new VideoClipEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ShowReelEntityConfiguration());
    }

}

