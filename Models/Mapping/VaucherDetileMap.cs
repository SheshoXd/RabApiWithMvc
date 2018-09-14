using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class VaucherDetileMap : EntityTypeConfiguration<VaucherDetile>
    {
        public VaucherDetileMap()
        {
            // Primary Key
            this.HasKey(t => t.VauDtilId);

            // Properties
            // Table & Column Mappings
            this.ToTable("VaucherDetiles");
            this.Property(t => t.VauDtilId).HasColumnName("VauDtilId");
            this.Property(t => t.ItemId).HasColumnName("ItemId");
            this.Property(t => t.qty).HasColumnName("qty");
            this.Property(t => t.CaseNo).HasColumnName("CaseNo");
            this.Property(t => t.CaseWds).HasColumnName("CaseWds");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.isDeleted).HasColumnName("isDeleted");
            this.Property(t => t.VauId).HasColumnName("VauId");
            this.Property(t => t.ItemPrice).HasColumnName("ItemPrice");
            this.Property(t => t.TotalPrice).HasColumnName("TotalPrice");
            // Relationships
            this.HasOptional(t => t.Vaucher)
                .WithMany(t => t.VaucherDetiles)
                .HasForeignKey(d => d.VauId);

        }
    }
}
