using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class AreaMap : EntityTypeConfiguration<Area>
    {
        public AreaMap()
        {
          
            // Primary Key
            this.HasKey(t => t.AreaId);

            // Properties
            this.Property(t => t.Area1)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Areas");
            this.Property(t => t.AreaId).HasColumnName("AreaId");
            this.Property(t => t.Area1).HasColumnName("Area");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.dateCreated).HasColumnName("dateCreated");
            this.Property(t => t.isDeleted).HasColumnName("isDeleted");
        }
    }
}
