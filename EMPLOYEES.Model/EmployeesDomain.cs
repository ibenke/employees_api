using EMPLOYEES.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMPLOYEES.Model
{
    public class EmployeesDomain
    {
        public EmployeesDomain()
        {
            
        }

        public EmployeesDomain(EmployeesIbenke employee)
        {
            EmpNo = employee.EmpNo;
            BirthDate = employee.BirthDate;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Gender = employee.Gender;
            HireDate = employee.HireDate;
        }

        public int EmpNo { get; set; }
        public DateTime? BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
