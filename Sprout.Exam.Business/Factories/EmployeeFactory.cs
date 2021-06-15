using Sprout.Exam.Business.Contracts.Factories;
using Sprout.Exam.Business.Contracts.Models;
using Sprout.Exam.Business.Models;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Factories
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public IEmployee GetEmployee(Employee employee)
        {
            if (employee.TypeId == (int)EmployeeType.Regular)
                return new RegularEmployee(employee);
            else if (employee.TypeId == (int)EmployeeType.Contractual)
                return new ContractualEmployee(employee);
            else
                throw new Exception("Employee Type not found");
        }
    }
}
