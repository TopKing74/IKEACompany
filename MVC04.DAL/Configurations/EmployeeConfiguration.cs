using MVC04.DAL.Models.Employee;
using MVC04.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.DAL.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> E)
        {
            E.Property(D => D.Name).HasColumnType("varchar(50)");
            E.Property(D => D.Address).HasColumnType("varchar(150)");
            E.Property(D => D.Salary).HasColumnType("decimal(7,2)");
            E.Property(D => D.Gender).HasConversion
                ((empgender) => empgender.ToString(),(gender)=>(Gender)Enum.Parse(typeof(Gender),gender));
            E.Property(D => D.EmployeeType).HasConversion
                ((emptype) => emptype.ToString(), (type) => (EmployeeType)Enum.Parse(typeof(EmployeeType), type));
        }
    }
}
