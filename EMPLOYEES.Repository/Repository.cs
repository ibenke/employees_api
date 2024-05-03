using EMPLOYEES.DAL.DataModel;
using EMPLOYEES.Repository;
using EMPLOYEES.Repository.Common;
using EMPLOYEES.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EMPLOYEES.Repository
{
    public class Repository : IRepository
    {
        private readonly EMPLOYEES_DbContext _appDbContext; 
        private IRepositoryMappingService _mappingService;

        public Repository(EMPLOYEES_DbContext appDbContext, IRepositoryMappingService mapper)
        {
            _appDbContext = appDbContext;
            _mappingService = mapper;
        }

        public async Task<bool> AddEmployeeAsync(EmployeesDomain employeeDomain)
        {
            try
            {
                EntityEntry<EmployeesIbenke> employee_created = await _appDbContext.EmployeesIbenke.AddAsync(_mappingService.Map<EmployeesIbenke>(employeeDomain));
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<EmployeesIbenke> GetAllEmployeesDb()
        {
            IEnumerable<EmployeesIbenke> employeesDb = _appDbContext.EmployeesIbenke.ToList();
            return employeesDb;
        }

        public IEnumerable<EmployeesDomain> GetAllEmployeesDomain()
        {
            IEnumerable<EmployeesIbenke> employeesDb = _appDbContext.EmployeesIbenke.ToList();
            IEnumerable<EmployeesDomain> employeesDomains = _mappingService.Map<IEnumerable<EmployeesDomain>>(employeesDb);
            return employeesDomains;
        }

        public EmployeesDomain GetEmployeeDomainByEmployeeId(int employeeId)
        {
            EmployeesIbenke employeeDb = _appDbContext.EmployeesIbenke.Find(employeeId);
            EmployeesDomain employeeDomain = _mappingService.Map<EmployeesDomain>(employeeDb);
            return employeeDomain;
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeesDomain employeeDomain)
        {
            try
            {
                EmployeesIbenke employeeDb = _appDbContext.EmployeesIbenke.Find(employeeDomain.EmpNo);
                if (employeeDb != null)
                {
                    employeeDb.BirthDate = employeeDomain.BirthDate;
                    employeeDb.FirstName = employeeDomain.FirstName;
                    employeeDb.LastName = employeeDomain.LastName;
                    employeeDb.Gender = employeeDomain.Gender;
                    employeeDb.HireDate = employeeDomain.HireDate;
                    _appDbContext.EmployeesIbenke.Update(employeeDb);
                    await _appDbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteEmployeeAsync(EmployeesDomain employeeDomain)
        {
            try
            {
                EmployeesIbenke employeeDb = _appDbContext.EmployeesIbenke.Find(employeeDomain.EmpNo);
                if (employeeDb != null)
                {
                    _appDbContext.EmployeesIbenke.Remove(employeeDb);
                    await _appDbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
