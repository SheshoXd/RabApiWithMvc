using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class CarMap : EntityTypeConfiguration<Car>
    {
        public CarMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CarNo });

            // Properties
            this.Property(t => t.CarNo)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.CarDiscripe)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.CarName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Car");
            this.Property(t => t.CarId).HasColumnName("CarId");
            this.Property(t => t.CarNo).HasColumnName("CarNo");
            this.Property(t => t.CarDiscripe).HasColumnName("CarDiscripe");
            this.Property(t => t.EmpId).HasColumnName("EmpId");
            this.Property(t => t.CarName).HasColumnName("CarName");
            this.Property(t => t.DateCreate).HasColumnName("DateCreate");
            this.Property(t => t.isDeleted).HasColumnName("isDeleted");
        }
    }
}
