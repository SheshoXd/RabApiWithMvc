using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            //this.HasRequired(x => x.Area).WithMany().Map(x => x.MapKey("AreaId"));

            // Primary Key
            this.HasKey(t => t.ClntId);

            // Properties
            this.Property(t => t.ClntName)
                .HasMaxLength(150);

            this.Property(t => t.Type)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.fullAddress)
                .IsFixedLength()
                .HasMaxLength(250);

            this.Property(t => t.OwnerName)
                .IsFixedLength()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Clients");
            this.Property(t => t.ClntId).HasColumnName("ClntId");
            this.Property(t => t.ClntName).HasColumnName("ClntName");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.fullAddress).HasColumnName("fullAddress");
            this.Property(t => t.OwnerName).HasColumnName("OwnerName");
            this.Property(t => t.PhoneNo).HasColumnName("PhoneNo");
            this.Property(t => t.AreaId).HasColumnName("AreaId");
            this.Property(t => t.ClntDebit).HasColumnName("ClntDebit");
            this.Property(t => t.ClntCreditor).HasColumnName("ClntCreditor");
            this.Property(t => t.ClntBalance).HasColumnName("ClntBalance");
            this.Property(t => t.ClntMaxBalance).HasColumnName("ClntMaxBalance");
            this.Property(t => t.ClntPaymants).HasColumnName("ClntPaymants");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");

            // Relationships
            this.HasOptional(t => t.Area)
                .WithMany(t => t.Clients)
                .HasForeignKey(d => d.AreaId);

        }
    }
}
