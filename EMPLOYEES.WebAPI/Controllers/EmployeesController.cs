using EMPLOYEES.DAL.DataModel;
using EMPLOYEES.Model;
using EMPLOYEES.Service.Common;
using EMPLOYEES.WebAPI.Controllers.RESTModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMPLOYEES.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // Ruza za pristup kontroleru (u ovom slučaju /employees)
    public class EmployeesController : ControllerBase
    {
        //servis za pružanje operacija nad zaposlenicima
        protected IService _service {  get; private set; }

        //konstruktor u kojem se inicijalizira servis
        public EmployeesController(IService service)
        {
            _service = service;
        }

        /*
        [HttpGet]
        [Route("employees_db")]
        public IEnumerable<EmployeesIbenke> GetAllUsersDb()
        {
            IEnumerable<EmployeesIbenke> employeesDb = _service.GetAllEmployeesDb();
            return employeesDb;
        }
        */
        //VRATI SVE ZAPOSLENIKE => https://localhost:5001/employees
        [HttpGet]
        //[Route("employees")]
        public IEnumerable<EmployeesDomain> GetEmployeesDomains()
        {
            //vraća sve zaposlenike u obliku EmployeesDomain klase
            IEnumerable<EmployeesDomain> employeesDomains = _service.GetAllEmployeesDomain();
            return employeesDomains;
        }

        //VRATI JEDNOG ZAPOSLENIKA => https://localhost:5001/employees/employee_id/1
        [HttpGet]
        [Route("employee_id/{employeeId}")]
        public EmployeesDomain GetEmployeesDomain(int employeeId) {
            //vraća zaposlenika prema id-u
            EmployeesDomain employeesDomain = _service.GetEmployeeDomainByEmployeeId(employeeId);
            return employeesDomain;
        }

        //DODAJ ZAPOSLENIKA => https://localhost:5001/employees/add
        //POTREBNO POSLATI OBJEKT U OBLIKU KAO ŠTO JE NAVEDENO ISPOD
        /*
        {
	        "BirthDate":"1985-04-12",
	        "FirstName":"Danijel",
	        "LastName":"Testić",
            "Gender": "M",
            "HireDate": "2021-04-12"
        }
         */
        [HttpPost]
        [Route("add")]
        
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeREST employeeREST)
        {
            try
            {
                //kreira novog zaposlenika prema EmployeeREST klasi
                EmployeesDomain employeesDomain = new EmployeesDomain();
                employeesDomain.BirthDate = employeeREST.BirthDate;
                employeesDomain.FirstName = employeeREST.FirstName;
                employeesDomain.LastName = employeeREST.LastName;
                employeesDomain.Gender = employeeREST.Gender;
                employeesDomain.HireDate = employeeREST.HireDate;

                bool add_user = await _service.AddEmployeeAsync(employeesDomain);
                if (add_user)
                {
                    return Ok("Employee dodan");
                }
                else
                {
                    return Ok("Employee nije dodan");
                }
            }catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.ToString()); ;
            }
        }

        //UREDI ZAPOSLENIKA => https://localhost:5001/employees/edit
        //POTREBNO POSLATI OBJEKT U OBLIKU KAO ŠTO JE NAVEDENO ISPOD
        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromBody] EmployeeREST employeeREST)
        {
            /*
            BODY:
			{
				"EmpNo":1,
				"BirthDate":"1985-04-12",
	            "FirstName":"Danijel",
	            "LastName":"Testić",
                "Gender": "M",
                "HireDate": "2021-04-12"
			}
             */

            try
            {
                EmployeesDomain employeesDomain = new EmployeesDomain();
                employeesDomain.EmpNo = employeeREST.EmpNo;
                employeesDomain.FirstName = employeeREST.FirstName;
                employeesDomain.LastName = employeeREST.LastName;
                employeesDomain.BirthDate = employeeREST.BirthDate;
                employeesDomain.Gender = employeeREST.Gender;
                employeesDomain.HireDate = employeeREST.HireDate;
                bool update_employee = await _service.UpdateEmployeeAsync(employeesDomain);
                if (update_employee)
                {
                    return Ok("Employee ažuriran");
                }
                else
                {
                    return Ok("Employee nije ažuriran");
                }
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        //obriši ZAPOSLENIKA => https://localhost:5001/employees/delete
        //POTREBNO POSLATI OBJEKT U OBLIKU KAO ŠTO JE NAVEDENO ISPOD
        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromBody] EmployeeREST employeeREST)
        {
            /*
            BODY:
			{
				"EmpNo":1,
			}
             */

            try
            {
                EmployeesDomain employeesDomain = new EmployeesDomain();
                employeesDomain.EmpNo = employeeREST.EmpNo;
                bool delete_employee = await _service.DeleteEmployeeAsync(employeesDomain);
                if (delete_employee)
                {
                    return Ok("Employee obrisan");
                }
                else
                {
                    return Ok("Employee nije obrisan");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
