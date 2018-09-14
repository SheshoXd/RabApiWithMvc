using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class VaucherMap : EntityTypeConfiguration<Vaucher>
    {
        public VaucherMap()
        {

            // Primary Key
            this.HasKey(t => t.VauId);

            // Properties
            this.Property(t => t.VauAmoTxt)
                .HasMaxLength(600);

            // Table & Column Mappings
            this.ToTable("Vaucher");
            this.Property(t => t.VauId).HasColumnName("VauId");
            this.Property(t => t.VauDate).HasColumnName("VauDate");
            this.Property(t => t.ClntId).HasColumnName("ClntId");
              this.Property(t => t.SlOrdId).HasColumnName("SlOrdId");
            this.Property(t => t.VauAmount).HasColumnName("VauAmount");
                        this.Property(t => t.PayAmount).HasColumnName("PayAmount");

           
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.VauAmoTxt).HasColumnName("VauAmoTxt");
            this.Property(t => t.VauOldAmunt).HasColumnName("VauOldAmunt");
            this.Property(t => t.VauStatus).HasColumnName("VauStatus");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");

            // Relationships
            this.HasOptional(t => t.Client)
                .WithMany(t => t.Vauchers)
                .HasForeignKey(d => d.ClntId);

        }
    }
}
