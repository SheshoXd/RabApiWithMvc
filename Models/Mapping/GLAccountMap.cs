using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class GLAccountMap : EntityTypeConfiguration<GLAccount>
    {
        public GLAccountMap()
        {
            // Primary Key
            this.HasKey(t => t.GLAccId);

            // Properties
            this.Property(t => t.AccType)
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("GLAccount");
            this.Property(t => t.GLAccId).HasColumnName("GLAccId");
            this.Property(t => t.AccType).HasColumnName("AccType");
            this.Property(t => t.AccId).HasColumnName("AccId");
            this.Property(t => t.GlCreditor).HasColumnName("GlCreditor");
            this.Property(t => t.GLDebit).HasColumnName("GLDebit");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.GLBalance).HasColumnName("GLBalance");
           
        }
    }
}
