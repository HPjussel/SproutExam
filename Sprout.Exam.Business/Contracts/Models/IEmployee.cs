using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Contracts.Models
{
    public interface IEmployee
    {
        decimal Compute(decimal absentDays, decimal workedDays);
    }
}
