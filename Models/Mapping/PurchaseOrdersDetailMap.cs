using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class PurchaseOrdersDetailMap : EntityTypeConfiguration<PurchaseOrdersDetail>
    {
        public PurchaseOrdersDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderDitId);

            // Properties
            // Table & Column Mappings
            this.ToTable("PurchaseOrdersDetails");
            this.Property(t => t.OrderDitId).HasColumnName("OrderDitId");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.OrderType).HasColumnName("OrderType");
            this.Property(t => t.QtyReq).HasColumnName("QtyReq");
            this.Property(t => t.ItemPrice).HasColumnName("ItemPrice");
            this.Property(t => t.itemId).HasColumnName("itemId");
            this.Property(t => t.TotalPrice).HasColumnName("TotalPrice");
            this.Property(t => t.CaseNumber).HasColumnName("CaseNumber");
            this.Property(t => t.CaseWight).HasColumnName("CaseWight");
            this.Property(t => t.PostingStatus).HasColumnName("PostingStatus");
            this.Property(t => t.StoredQty).HasColumnName("StoredQty");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.WightEmpty).HasColumnName("WightEmpty");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.PurchaseOrdersDetails)
                .HasForeignKey(d => d.itemId);
            this.HasRequired(t => t.PurchaseOrder)
                .WithMany(t => t.PurchaseOrdersDetails)
                .HasForeignKey(d => new { d.Id, d.OrderId, d.OrderType });

        }
    }
}
