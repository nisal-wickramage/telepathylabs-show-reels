using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelepathyLabs.ShowReels.Domain;
using System.Text.Json;

namespace TelepathyLabs.ShowReels.DataAccess
{
    public class VideoClipEntityConfiguration : IEntityTypeConfiguration<VideoClip>
    {
        public void Configure(EntityTypeBuilder<VideoClip> builder)
        {
            builder.ToTable("VideoClips");
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(v => v.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(v => v.Description)
                .HasColumnName("Description")
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(v => v.VideoDefinition)
                .HasColumnName("VideoDefinition")
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(v => v.VideoStandard)
                .HasColumnName("VideoStandard")
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(v => v.StartTimeCode)
                .HasColumnName("StartTimeCode")
                .HasColumnType("varchar(200)")
                .HasConversion(
                    t => JsonSerializer.Serialize(t, new JsonSerializerOptions { WriteIndented = false }),
                    t => JsonSerializer.Deserialize<TimeCode>(t, new JsonSerializerOptions { WriteIndented = false }))
                .IsRequired();

            builder.Property(v => v.EndTimeCode)
                .HasColumnName("EndTimeCode")
                .HasColumnType("varchar(200)")
                .HasConversion(
                    t => JsonSerializer.Serialize(t, new JsonSerializerOptions { WriteIndented = false }),
                    t => JsonSerializer.Deserialize<TimeCode>(t, new JsonSerializerOptions { WriteIndented = false }))
                .IsRequired();
        }
    }
}

