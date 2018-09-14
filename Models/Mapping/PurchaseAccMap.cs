using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class PurchaseAccMap : EntityTypeConfiguration<PurchaseAcc>
    {
        public PurchaseAccMap()
        {
            // Primary Key
            this.HasKey(t => t.PurAccId);

            // Properties
            this.Property(t => t.PurAccDisc)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("PurchaseAcc");
            this.Property(t => t.PurAccId).HasColumnName("PurAccId");
            this.Property(t => t.PurAccDisc).HasColumnName("PurAccDisc");
            this.Property(t => t.PurAddDebet).HasColumnName("PurAddDebet");
            this.Property(t => t.PurAccCreadit).HasColumnName("PurAccCreadit");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.isDeleted).HasColumnName("isDeleted");
        }
    }
}
