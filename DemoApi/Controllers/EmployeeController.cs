using Core.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private static List<Employee> employees = new List<Employee>
        {
            new Employee{Id = 1, Name = "Shaun", Email = "a@gmail.com", PhoneNumber = "012356789"},
            new Employee{Id = 2, Name = "Habib", Email = "b@gmail.com", PhoneNumber = "014556789"},
            new Employee{Id = 3, Name = "Shayan", Email = "c@gmail.com", PhoneNumber = "08568356789"},
            new Employee{Id = 4, Name = "Ahmed", Email = "d@gmail.com", PhoneNumber = "01256356789"},
        };


        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(employees);
        }

        
        [HttpGet]
        public IActionResult Get(int id)
        {
            var rs = employees.FirstOrDefault(x => x.Id == id);
            return Ok(rs);
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] Employee emp)
        {
            if (emp != null)
            {
                employees.Add(emp);
                return Ok("Success");
            }
            return Ok("Failed");
        }

        
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Employee emp)
        {
            var exEmp = employees.FirstOrDefault(x => x.Id == id);
            if (exEmp != null)
            {
                employees.Remove(exEmp);
            }
            employees.Add(emp);
            return Ok("Success");
        }

        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var exEmp = employees.FirstOrDefault(x => x.Id == id);
            if (exEmp != null)
            {
                employees.Remove(exEmp);
                return Ok("Success");
            }
            return Ok("Failed");
        }
    }
}
