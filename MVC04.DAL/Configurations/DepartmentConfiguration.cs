using MVC04.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.DAL.Configurations
{
    internal class DepartmentConfigurationscs : IEntityTypeConfiguration<Department>
    {
        void IEntityTypeConfiguration<Department>.Configure(EntityTypeBuilder<Department> D)
        {
            D.Property(D => D.Id).UseIdentityColumn(10, 10);
            D.Property(D => D.CreatedOn).HasDefaultValueSql("GetDate()");
            D.Property(D => D.LastUpdatedOn).HasComputedColumnSql("GetDate()");
            D.Property(D => D.Name).HasColumnType("Varchar(25)");
            D.Property(D => D.Code).HasColumnType("Varchar(25)");
            D.HasMany(D => D.Employees)
                .WithOne(E => E.Department)
                .HasForeignKey(E => E.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
