using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class SupplierMap : EntityTypeConfiguration<Supplier>
    {

        public SupplierMap()
        {
            //this.HasRequired(x => x.Area).WithMany().Map(x => x.MapKey("AreaId"));

            // Primary Key
            this.HasKey(t => t.SuppId);

            // Properties
            this.Property(t => t.SuppName)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.fullAddress)
                .HasMaxLength(500);

            this.Property(t => t.OwnerName)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Suppliers");
            this.Property(t => t.SuppId).HasColumnName("SuppId");
            this.Property(t => t.SuppName).HasColumnName("SuppName");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.fullAddress).HasColumnName("fullAddress");
            this.Property(t => t.OwnerName).HasColumnName("OwnerName");
            this.Property(t => t.PhoneNo).HasColumnName("PhoneNo");
            this.Property(t => t.AreaId).HasColumnName("AreaId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");

            // Relationships
            this.HasOptional(t => t.Area)
                .WithMany(t => t.Suppliers)
                .HasForeignKey(d => d.AreaId);

        }
    }
}
