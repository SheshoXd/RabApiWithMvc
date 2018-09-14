using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class StoreItemMap : EntityTypeConfiguration<StoreItem>
    {
        public StoreItemMap()
        {
            // Primary Key
            this.HasKey(t => t.StoreItemId);

            // Properties
            // Table & Column Mappings
            this.ToTable("StoreItem");
            this.Property(t => t.StoreItemId).HasColumnName("StoreItemId");
            this.Property(t => t.ItemId).HasColumnName("ItemId");
            this.Property(t => t.itemQyt).HasColumnName("itemQyt");
            this.Property(t => t.OpenBlance).HasColumnName("OpenBlance");
            this.Property(t => t.availableQty).HasColumnName("availableQty");
             this.Property(t => t.UnPostedQty).HasColumnName("UnPostedQty");
          

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.StoreItems)
                .HasForeignKey(d => d.ItemId);

        }
    }
}
