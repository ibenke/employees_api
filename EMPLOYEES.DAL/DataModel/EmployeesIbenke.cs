using System;
using System.Collections.Generic;

namespace EMPLOYEES.DAL.DataModel
{
    public partial class EmployeesIbenke
    {
        public int EmpNo { get; set; }
        public DateTime? BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
