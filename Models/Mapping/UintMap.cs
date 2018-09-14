using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class UintMap : EntityTypeConfiguration<Uint>
    {
        public UintMap()
        {
            // Primary Key
            this.HasKey(t => t.UintId);

            // Properties
            this.Property(t => t.UintId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UintName)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Uints");
            this.Property(t => t.UintId).HasColumnName("UintId");
            this.Property(t => t.UintName).HasColumnName("UintName");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
        }
    }
}
