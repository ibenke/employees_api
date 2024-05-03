using EMPLOYEES.DAL.DataModel;
using EMPLOYEES.Model;
using EMPLOYEES.Repository.Common;
using EMPLOYEES.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMPLOYEES.Service
{
    public class Service : IService
    {
        readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddEmployeeAsync(EmployeesDomain employee)
        {
            return await _repository.AddEmployeeAsync(employee);
        }

        public IEnumerable<EmployeesIbenke> GetAllEmployeesDb()
        {
            IEnumerable<EmployeesIbenke> employeesDb = _repository.GetAllEmployeesDb();
            return employeesDb;
        }

        public IEnumerable<EmployeesDomain> GetAllEmployeesDomain()
        {
            IEnumerable<EmployeesDomain> employeesDomains = _repository.GetAllEmployeesDomain();
            return employeesDomains;
        }

        public EmployeesDomain GetEmployeeDomainByEmployeeId(int employeeId)
        {
            EmployeesDomain employeesDomain = _repository.GetEmployeeDomainByEmployeeId(employeeId);
            return employeesDomain;
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeesDomain employee)
        {
            return await _repository.UpdateEmployeeAsync(employee);
        }

        public async Task<bool> DeleteEmployeeAsync(EmployeesDomain employee)
        {
            return await _repository.DeleteEmployeeAsync(employee);
        }
    }
}
