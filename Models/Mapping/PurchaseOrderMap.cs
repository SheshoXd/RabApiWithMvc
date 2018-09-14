using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class PurchaseOrderMap : EntityTypeConfiguration<PurchaseOrder>
    {
        public PurchaseOrderMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.OrderId, t.OrderType });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.OrderId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.OrderType)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("PurchaseOrders");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.OrderType).HasColumnName("OrderType");
            this.Property(t => t.EmpId).HasColumnName("EmpId");
            this.Property(t => t.SuppId).HasColumnName("SuppId");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.PaymantType).HasColumnName("PaymantType");
            this.Property(t => t.TotalPrice).HasColumnName("TotalPrice");
            this.Property(t => t.Debit).HasColumnName("Debit");
            this.Property(t => t.Creditor).HasColumnName("Creditor");
            this.Property(t => t.PostingStats).HasColumnName("PostingStats");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");

            // Relationships
            this.HasOptional(t => t.Employee)
                .WithMany(t => t.PurchaseOrders)
                .HasForeignKey(d => d.EmpId);
            this.HasOptional(t => t.Supplier)
                .WithMany(t => t.PurchaseOrders)
                .HasForeignKey(d => d.SuppId);

        }
    }
}
