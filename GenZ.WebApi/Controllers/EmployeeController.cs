using GenZ.Business.Service;
using GenZ.Database;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GenZ.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeservice;

        public EmployeeController(IEmployeeService employeeservice)
        {
            _employeeservice = employeeservice;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            try
            {
                var response = _employeeservice.GetAllEmployee();
                return response.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            try
            {
                return _employeeservice.GetEmployeeById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            try
            {
                _employeeservice.InsertEmployeeUsingEE(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            try
            {
                if (id != employee.Id)
                {
                    throw new ArgumentException("argument not matched");
                }
                _employeeservice.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _employeeservice.DeleteEmployee(id);
            }
            catch (Exception) { throw; }
        }
    }
}
