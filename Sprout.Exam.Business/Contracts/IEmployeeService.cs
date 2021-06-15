using Sprout.Exam.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> GetByIdAsync(int id);
        Task<EmployeeDto> CreateAsync(CreateEmployeeDto createEmployeeDto);
        Task EditAsync(EditEmployeeDto editEmployeeDto);
        Task DeleteAsync(int id);
        Task<decimal> ComputeAsync(int id, decimal absentDays, decimal workedDays);
    }
}
