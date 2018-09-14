using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class SaleOrderMap : EntityTypeConfiguration<SaleOrder>
    {
        public SaleOrderMap()
        {
            // Primary Key
            this.HasKey(t => t.SlOrdId);

            // Properties
            this.Property(t => t.SlOrdId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("SaleOrders");
            this.Property(t => t.SlOrdId).HasColumnName("SlOrdId");
            this.Property(t => t.EmpId).HasColumnName("EmpId");
            this.Property(t => t.ClntId).HasColumnName("ClntId");
            this.Property(t => t.SlOrdDate).HasColumnName("SlOrdDate");
            this.Property(t => t.PaymantType).HasColumnName("PaymantType");
            this.Property(t => t.TotalPrice).HasColumnName("TotalPrice");
            this.Property(t => t.Debit).HasColumnName("Debit");
            this.Property(t => t.Creditor).HasColumnName("Creditor");
            this.Property(t => t.PostingStats).HasColumnName("PostingStats");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");

            // Relationships
            this.HasRequired(t => t.Client)
                .WithMany(t => t.SaleOrders)
                .HasForeignKey(d => d.ClntId);
            this.HasOptional(t => t.Employee)
                .WithMany(t => t.SaleOrders)
                .HasForeignKey(d => d.EmpId);

        }
    }
}
