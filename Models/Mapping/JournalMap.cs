using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class JournalMap : EntityTypeConfiguration<Journal>
    {
        public JournalMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Journal");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.jornalType).HasColumnName("jornalType");
            this.Property(t => t.jorText).HasColumnName("jorText");
            this.Property(t => t.jorAmount).HasColumnName("jorAmount");
            this.Property(t => t.jorDate).HasColumnName("jorDate");
            this.Property(t => t.Debit).HasColumnName("Debit");
            this.Property(t => t.creadit).HasColumnName("creadit");
            this.Property(t => t.debType).HasColumnName("debType");
            this.Property(t => t.debId).HasColumnName("debId");
            this.Property(t => t.creadType).HasColumnName("creadType");
            this.Property(t => t.creadId).HasColumnName("creadId");
        }
    }
}
