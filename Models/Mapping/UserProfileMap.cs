using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.LastName)
                .HasMaxLength(100);

            this.Property(t => t.Address)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("UserProfiles");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.AddedDate).HasColumnName("AddedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.IP).HasColumnName("IP");

            // Relationships
            this.HasRequired(t => t.User)
                .WithOptional(t => t.UserProfile);

        }
    }
}
