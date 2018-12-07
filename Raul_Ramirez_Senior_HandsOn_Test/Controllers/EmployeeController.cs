using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Model.Model;

namespace Raul_Ramirez_Senior_HandsOn_Test.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositoryEmployee repository;

        public EmployeeController(IRepositoryEmployee repository)
        {
            this.repository = repository;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<IEnumerable<FactoryEmployee>> GetEmployeesAsync()
        {

            var employees = await repository.GetEmployeesAsync();
            List<FactoryEmployee> factoryEmployees = new List<FactoryEmployee>();
            foreach (var e in employees)
            {
                if (e.ContractTypeName.Equals("HourlySalaryEmployee"))
                {
                    factoryEmployees.Add(new EmployeeContractHourly(e.HourlySalary)
                    {
                        Id = e.Id,
                        Name = e.Name,
                        ContractTypeName = e.ContractTypeName,
                        RoleId = e.RoleId,
                        RoleName = e.RoleName
                    });
                }
                else if(e.ContractTypeName.Equals("MonthlySalaryEmployee"))
                {
                    factoryEmployees.Add(new EmployeeContractMonthly(e.MonthlySalary)
                    {
                        Id = e.Id,
                        Name = e.Name,
                        ContractTypeName = e.ContractTypeName,
                        RoleId = e.RoleId,
                        RoleName = e.RoleName
                    });
                }
            }

            return factoryEmployees;
        }

        #region GetEmployee
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await repository.GetEmployeeAsync(id);

            if (employee == null)
            {
                return NotFound(id);
            }

            List<FactoryEmployee> factoryEmployees = new List<FactoryEmployee>();
            foreach (var e in employee)
            {
                if (e.ContractTypeName.Equals("HourlySalaryEmployee"))
                {
                    factoryEmployees.Add(new EmployeeContractHourly(e.HourlySalary)
                    {
                        Id = e.Id,
                        Name = e.Name,
                        ContractTypeName = e.ContractTypeName,
                        RoleId = e.RoleId,
                        RoleName = e.RoleName
                    });
                }
                else if (e.ContractTypeName.Equals("MonthlySalaryEmployee"))
                {
                    factoryEmployees.Add(new EmployeeContractMonthly(e.MonthlySalary)
                    {
                        Id = e.Id,
                        Name = e.Name,
                        ContractTypeName = e.ContractTypeName,
                        RoleId = e.RoleId,
                        RoleName = e.RoleName
                    });
                }
            }


            return Ok(factoryEmployees);
        }
        #endregion


    }
}
