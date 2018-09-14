using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class ItemMap : EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ItemId);

            // Properties
            this.Property(t => t.ItemName)
                .HasMaxLength(100);

            this.Property(t => t.ItemDescription)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Items");
            this.Property(t => t.ItemId).HasColumnName("ItemId");
            this.Property(t => t.ItemName).HasColumnName("ItemName");
            this.Property(t => t.ItemDescription).HasColumnName("ItemDescription");
            this.Property(t => t.AverageCost).HasColumnName("AverageCost");
            this.Property(t => t.itemQyt).HasColumnName("itemQyt");
            this.Property(t => t.OpenBlance).HasColumnName("OpenBlance");
            this.Property(t => t.availableQty).HasColumnName("availableQty");
            this.Property(t => t.UnPostedQty).HasColumnName("UnPostedQty");
            this.Property(t => t.UintId).HasColumnName("UintId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.itemDepr).HasColumnName("itemDepr");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");

            // Relationships
            this.HasRequired(t => t.Uint)
                .WithMany(t => t.Items)
                .HasForeignKey(d => d.UintId);

        }
    }
}
