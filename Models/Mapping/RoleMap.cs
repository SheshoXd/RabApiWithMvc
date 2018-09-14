using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RoleName)
                .HasMaxLength(20);

            this.Property(t => t.RoleDescribe)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Role");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RoleName).HasColumnName("RoleName");
            this.Property(t => t.RoleDescribe).HasColumnName("RoleDescribe");
        }
    }
}
