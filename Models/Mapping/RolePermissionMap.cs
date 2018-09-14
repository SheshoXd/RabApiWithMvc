using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class RolePermissionMap : EntityTypeConfiguration<RolePermission>
    {
        public RolePermissionMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PermissionsName)
                .HasMaxLength(50);

            this.Property(t => t.KeyPermissions)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("RolePermissions");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RID).HasColumnName("RID");
            this.Property(t => t.PermissionsName).HasColumnName("PermissionsName");
            this.Property(t => t.ReadPermissions).HasColumnName("ReadPermissions");
            this.Property(t => t.WritePermissions).HasColumnName("WritePermissions");
            this.Property(t => t.DeletePermissions).HasColumnName("DeletePermissions");
            this.Property(t => t.FullPermissions).HasColumnName("FullPermissions");
            this.Property(t => t.KeyPermissions).HasColumnName("KeyPermissions");

            // Relationships
            this.HasOptional(t => t.Role)
                .WithMany(t => t.RolePermissions)
                .HasForeignKey(d => d.RID);

        }
    }
}
