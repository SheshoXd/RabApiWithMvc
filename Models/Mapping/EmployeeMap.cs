using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RabApiWithMvc.Models.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            // Primary Key
            this.HasKey(t => t.EmpId);

            // Properties
            this.Property(t => t.EmpName)
                .HasMaxLength(250);

            this.Property(t => t.EmpAddress)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Employees");
            this.Property(t => t.EmpId).HasColumnName("EmpId");
            this.Property(t => t.EmpName).HasColumnName("EmpName");
            this.Property(t => t.EmpAddress).HasColumnName("EmpAddress");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.isDeleted).HasColumnName("isDeleted");
        }
    }
}
