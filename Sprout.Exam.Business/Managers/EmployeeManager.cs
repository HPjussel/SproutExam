using Sprout.Exam.Business.Contracts;
using Sprout.Exam.Business.Contracts.Factories;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.DataAccess.Contracts;
using Sprout.Exam.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Managers
{
    public class EmployeeManager : IEmployeeService
    {
        private IEmployeeRepository _employeeRepo;
        private IEmployeeFactory _employeeFactory;
        public EmployeeManager(IEmployeeRepository employeeRepo, IEmployeeFactory employeeFactory)
        {
            _employeeRepo = employeeRepo;
            _employeeFactory = employeeFactory;
        }

        public async Task<decimal> ComputeAsync(int id, decimal absentDays, decimal workedDays)
        {
            try
            {
                var employee = await _employeeRepo.GetByIdAsync(id);
                var concreteEmployee = _employeeFactory.GetEmployee(employee);
                return concreteEmployee.Compute(absentDays, workedDays);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto createEmployeeDto)
        {
            try
            {
                var employee = new Employee
                {
                    Birthdate = createEmployeeDto.Birthdate,
                    FullName = createEmployeeDto.FullName,
                    Tin = createEmployeeDto.Tin,
                    TypeId = createEmployeeDto.TypeId
                };
                var createdEmployee = await _employeeRepo.AddAsync(employee);

                return new EmployeeDto
                {
                    Birthdate = createdEmployee.Birthdate,
                    FullName = createdEmployee.FullName,
                    Tin = createdEmployee.Tin,
                    TypeId = createdEmployee.TypeId,
                    Id = createdEmployee.Id
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var employee = await _employeeRepo.GetByIdAsync(id); 
                await _employeeRepo.DeleteAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task EditAsync(EditEmployeeDto editEmployeeDto)
        {
            try
            {
                var employee = new Employee
                {
                    Id = editEmployeeDto.Id,
                    Birthdate = editEmployeeDto.Birthdate,
                    FullName = editEmployeeDto.FullName,
                    Tin = editEmployeeDto.Tin,
                    TypeId = editEmployeeDto.TypeId
                };
                await _employeeRepo.UpdateAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            try
            {
                var employees = await _employeeRepo.GetAllAsync(e => e.IsDeleted == false);
                return employees.Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    Tin = e.Tin,
                    Birthdate = e.Birthdate,
                    TypeId = e.TypeId
                });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            try
            {
                var employee = await _employeeRepo.GetByIdAsync(id);
                return new EmployeeDto
                {
                    Id = employee.Id,
                    FullName = employee.FullName,
                    Tin = employee.Tin,
                    Birthdate = employee.Birthdate,
                    TypeId = employee.TypeId
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
