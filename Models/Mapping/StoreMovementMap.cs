using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class StoreMovementMap : EntityTypeConfiguration<StoreMovement>
    {
        public StoreMovementMap()
        {
            // Primary Key
            this.HasKey(t => t.StoremoveId);

            // Properties
            // Table & Column Mappings
            this.ToTable("StoreMovement");
            this.Property(t => t.StoremoveId).HasColumnName("StoremoveId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.ItemId).HasColumnName("ItemId");
            this.Property(t => t.OrderDetailsId).HasColumnName("OrderDetailsId");
            this.Property(t => t.MovementType).HasColumnName("MovementType");
            this.Property(t => t.itemQty).HasColumnName("itemQty");
            this.Property(t => t.type).HasColumnName("type");

            // Relationships
            this.HasOptional(t => t.Item)
                .WithMany(t => t.StoreMovements)
                .HasForeignKey(d => d.ItemId);

        }
    }
}
