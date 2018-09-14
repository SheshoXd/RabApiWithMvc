using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class CreaditMap : EntityTypeConfiguration<Creadit>
    {
        public CreaditMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Creadit");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.ClintId).HasColumnName("ClintId");
            this.Property(t => t.CreaditAmount).HasColumnName("CreaditAmount");

            // Relationships
            this.HasOptional(t => t.Client)
                .WithMany(t => t.Creadits)
                .HasForeignKey(d => d.ClintId);

        }
    }
}
