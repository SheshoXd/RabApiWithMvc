using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class ClientAccountMap : EntityTypeConfiguration<ClientAccount>
    {
        public ClientAccountMap()
        {
            // Primary Key
            this.HasKey(t => t.ClntAccId);
     
            // Properties 
            this.Property(t => t.MoveType).HasMaxLength(2);
            // Table & Column Mappings
            this.ToTable("ClientAccount");
            this.Property(t => t.ClntAccId).HasColumnName("ClntAccId");
            this.Property(t => t.ClntId).HasColumnName("ClntId");
            this.Property(t => t.ClntDebit).HasColumnName("ClntDebit");
            this.Property(t => t.ClntCreditor).HasColumnName("ClntCreditor");
            this.Property(t => t.ClntBalance).HasColumnName("ClntBalance");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.MoveType).HasColumnName("MoveType");
            

            // Relationships
            this.HasOptional(t => t.Client)
                .WithMany(t => t.ClientAccounts)
                .HasForeignKey(d => d.ClntId);

        }
    }
}
