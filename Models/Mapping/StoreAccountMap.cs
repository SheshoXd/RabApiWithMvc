using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class StoreAccountMap : EntityTypeConfiguration<StoreAccount>
    {
        public StoreAccountMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("StoreAccount");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RefType).HasColumnName("RefType");
            this.Property(t => t.RefId).HasColumnName("RefId");
            this.Property(t => t.StoreCreditor).HasColumnName("StoreCreditor");
            this.Property(t => t.StoreDebit).HasColumnName("StoreDebit");
            this.Property(t => t.AccType).HasColumnName("AccType");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");

           

        }
    }
}
