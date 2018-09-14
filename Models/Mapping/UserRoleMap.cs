using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("UserRoles");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RID).HasColumnName("RID");
            this.Property(t => t.UID).HasColumnName("UID");

            // Relationships
            this.HasOptional(t => t.Role)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(d => d.RID);
            this.HasOptional(t => t.User)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(d => d.UID);

        }
    }
}
