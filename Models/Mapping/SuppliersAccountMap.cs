using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class SuppliersAccountMap : EntityTypeConfiguration<SuppliersAccount>
    {
        public SuppliersAccountMap()
        {
            // Primary Key
            this.HasKey(t => t.SuppAccId);

            // Properties
            // Table & Column Mappings
            this.ToTable("SuppliersAccount");
            this.Property(t => t.SuppAccId).HasColumnName("SuppAccId");
            this.Property(t => t.SuppId).HasColumnName("SuppId");
            this.Property(t => t.SuppCreditor).HasColumnName("SuppCreditor");
            this.Property(t => t.SuppDebit).HasColumnName("SuppDebit");
            this.Property(t => t.AccType).HasColumnName("AccType");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");

            // Relationships
            this.HasOptional(t => t.Supplier)
                .WithMany(t => t.SuppliersAccounts)
                .HasForeignKey(d => d.SuppId);

        }
    }
}
