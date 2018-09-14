using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class CasTodyMap : EntityTypeConfiguration<CasTody>
    {
        public CasTodyMap()
        {
            // Primary Key
            this.HasKey(t => t.CastodyId);

            // Properties
            this.Property(t => t.CasFor)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("CasTody");
            this.Property(t => t.CastodyId).HasColumnName("CastodyId");
            this.Property(t => t.FildType).HasColumnName("FildType");
            this.Property(t => t.FildId).HasColumnName("FildId");
            this.Property(t => t.CasDebet).HasColumnName("CasDebet");
            this.Property(t => t.CasCredeit).HasColumnName("CasCredeit");
            this.Property(t => t.CasFor).HasColumnName("CasFor");
            this.Property(t => t.CasDate).HasColumnName("CasDate");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.isDeleted).HasColumnName("isDeleted");
        }
    }
}
