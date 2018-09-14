using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class DebitMap : EntityTypeConfiguration<Debit>
    {
        public DebitMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Debit");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.SuppID).HasColumnName("SuppID");
            this.Property(t => t.DebitAmount).HasColumnName("DebitAmount");

            // Relationships
            this.HasOptional(t => t.Supplier)
                .WithMany(t => t.Debits)
                .HasForeignKey(d => d.SuppID);

        }
    }
}
