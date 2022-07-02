using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TelepathyLabs.ShowReels.DataAccess
{
    internal class ShowReelEntityConfiguration: IEntityTypeConfiguration<ShowReelDbModel>
    {
        public void Configure(EntityTypeBuilder<ShowReelDbModel> builder)
        {
            builder.ToTable("ShowReels");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(s => s.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(s => s.VideoDefinition)
                .HasColumnName("VideoDefinition")
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(s => s.VideoStandard)
                .HasColumnName("VideoStandard")
                .HasColumnType("smallint")
                .IsRequired();

            builder.HasMany(s => s.VideoClips)
                .WithOne();
        }
    }
}

