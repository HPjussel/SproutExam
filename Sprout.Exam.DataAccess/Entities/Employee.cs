using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Entities
{
    public class Employee: DeleteableEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Tin { get; set; }
        [Column("EmployeeTypeId")]
        public int TypeId { get; set; } 
    }
}
