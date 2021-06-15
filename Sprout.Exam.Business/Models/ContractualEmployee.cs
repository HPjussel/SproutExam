using Sprout.Exam.Business.Contracts.Models;
using Sprout.Exam.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Models
{
    public class ContractualEmployee :Employee, IEmployee
    {
        public ContractualEmployee(Employee employee)
        {
            this.Id = employee.Id;
            this.Birthdate = employee.Birthdate;
            this.FullName = employee.FullName;
            this.IsDeleted = employee.IsDeleted;
            this.Tin = employee.Tin;
            this.TypeId = employee.TypeId;
        }

        private decimal _dailyRate = 500;

        public decimal Compute( decimal absentDays, decimal workedDays)
        {
            try
            {
                return decimal.Round(_dailyRate * workedDays);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
