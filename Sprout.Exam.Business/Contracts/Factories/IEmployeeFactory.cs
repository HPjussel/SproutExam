using Sprout.Exam.Business.Contracts.Models;
using Sprout.Exam.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Contracts.Factories
{
    public interface IEmployeeFactory
    {
        IEmployee GetEmployee(Employee employee);
    }
}
