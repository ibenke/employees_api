using EMPLOYEES.DAL.DataModel;
using EMPLOYEES.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMPLOYEES.Service.Common
{
    public interface IService
    {
        IEnumerable<EmployeesIbenke> GetAllEmployeesDb();
        IEnumerable<EmployeesDomain> GetAllEmployeesDomain();
        EmployeesDomain GetEmployeeDomainByEmployeeId(int employeeId);

        Task<bool> AddEmployeeAsync(EmployeesDomain employee);

        Task<bool> UpdateEmployeeAsync(EmployeesDomain employee);
        Task<bool> DeleteEmployeeAsync(EmployeesDomain employee);
    }
}
