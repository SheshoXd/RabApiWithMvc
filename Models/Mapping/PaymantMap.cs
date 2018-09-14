using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class PaymantMap : EntityTypeConfiguration<Paymant>
    {
        public PaymantMap()
        {
            // Primary Key
            this.HasKey(t => t.PayId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Paymants");
            this.Property(t => t.PayId).HasColumnName("PayId");
            this.Property(t => t.PayAmount).HasColumnName("PayAmount");
            this.Property(t => t.PayDate).HasColumnName("PayDate");
            this.Property(t => t.ClntId).HasColumnName("ClntId");
            this.Property(t => t.VauId).HasColumnName("VauId");
            

            // Relationships
            this.HasOptional(t => t.Client)
                .WithMany(t => t.Paymants)
                .HasForeignKey(d => d.ClntId);
            this.HasOptional(t => t.Vaucher)
                .WithMany(t => t.Paymants)
                .HasForeignKey(d => d.ClntId);

        }
    }
}
