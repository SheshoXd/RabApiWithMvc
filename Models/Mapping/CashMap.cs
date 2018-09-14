using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class CashMap : EntityTypeConfiguration<Cash>
    {
        public CashMap()
        {
            // Primary Key
            this.HasKey(t => t.CashId);

            // Properties
            this.Property(t => t.PayType)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Cash");
            this.Property(t => t.CashId).HasColumnName("CashId");
            this.Property(t => t.PayType).HasColumnName("PayType");
            this.Property(t => t.Debit).HasColumnName("Debit");
            this.Property(t => t.Creditor).HasColumnName("Creditor");
            this.Property(t => t.DataCreated).HasColumnName("DataCreated");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
        }
    }
}
