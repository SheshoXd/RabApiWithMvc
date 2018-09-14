using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.UserName)
                .IsRequired();

            this.Property(t => t.Email)
                .IsRequired();

            this.Property(t => t.Password)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.AddedDate).HasColumnName("AddedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IP).HasColumnName("IP");
        }
    }
}
