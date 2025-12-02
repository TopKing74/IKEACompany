using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC04.DAL.Models.Shared
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
        public int? LastUpdatedBy { get; set; }

        public DateTime LastUpdatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
