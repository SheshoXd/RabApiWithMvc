using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class SaleOrdersDetailMap : EntityTypeConfiguration<SaleOrdersDetail>
    {
        public SaleOrdersDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.SlOrdDtId);

            // Properties
            // Table & Column Mappings
            this.ToTable("SaleOrdersDetails");
            this.Property(t => t.ItemId).HasColumnName("ItemId");
            this.Property(t => t.SlOrdDtId).HasColumnName("SlOrdDtId");
            this.Property(t => t.SlOrdId).HasColumnName("SlOrdId");
            this.Property(t => t.ItemPrice).HasColumnName("ItemPrice");
            this.Property(t => t.TotalPrice).HasColumnName("TotalPrice");
            this.Property(t => t.SlQty).HasColumnName("SlQty");
            this.Property(t => t.CaseNumber).HasColumnName("CaseNumber");
            this.Property(t => t.CaseWight).HasColumnName("CaseWight");
            this.Property(t => t.PostingStatus).HasColumnName("PostingStatus");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.WightEmpty).HasColumnName("WightEmpty");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.SaleOrdersDetails)
                .HasForeignKey(d => d.ItemId);
            this.HasOptional(t => t.SaleOrder)
                .WithMany(t => t.SaleOrdersDetails)
                .HasForeignKey(d => d.SlOrdId);

        }
    }
}

