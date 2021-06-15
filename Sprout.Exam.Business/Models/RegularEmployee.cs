using Sprout.Exam.Business.Contracts.Models;
using Sprout.Exam.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Models
{
    public class RegularEmployee : Employee, IEmployee
    {
        public RegularEmployee(Employee employee)
        {
            this.Id = employee.Id;
            this.Birthdate = employee.Birthdate;
            this.FullName = employee.FullName;
            this.IsDeleted = employee.IsDeleted;
            this.Tin = employee.Tin;
            this.TypeId = employee.TypeId;
        }

        private decimal _basicSalary = 20000;
        private decimal _taxRate = 0.12M;
        private int _numberOfDays = 22;

        public decimal Compute( decimal absentDays, decimal workedDays)
        {
            try
            {
                var computedSalary = _basicSalary - (absentDays * (_basicSalary / _numberOfDays)) - (_basicSalary * _taxRate);
                return decimal.Round(computedSalary,2);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
