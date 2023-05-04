using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Refit;
using RefitApi.ApiService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RefitApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IEmployeeApiService _employeeApiService;
        public HomeController()
        {
            _employeeApiService = RestService.For<IEmployeeApiService>("http://localhost:5126/api");
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllEmp()
        {
            var rs = await _employeeApiService.GetEmployees();
            return Ok(rs);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetEmp(int id)
        {
            var rs = await _employeeApiService.GetEmployee(id);
            return Ok(rs);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateEmp([FromBody] Employee emp)
        {
            var rs = await _employeeApiService.CreateEmployee(emp);
            return Ok(rs);
        }

        
        [HttpPut]
        public async Task<IActionResult> UpdateEmp(int id, [FromBody] Employee emp)
        {
            var rs = await _employeeApiService.UpdateEmployee(id, emp);
            return Ok(rs);
        }

        
        [HttpDelete]
        public async Task<IActionResult> DeleteEmp(int id)
        {
            var rs = await _employeeApiService.DeleteEmployee(id);
            return Ok(rs);
        }
    }
}
