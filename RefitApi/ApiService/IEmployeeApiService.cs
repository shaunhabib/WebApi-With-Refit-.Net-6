using Core.Domain;
using Refit;

namespace RefitApi.ApiService
{
    //[Headers("Content-Type: application/json")]
    public interface IEmployeeApiService
    {
        [Get("/Employee/GetAll")]
        Task<List<Employee>> GetEmployees();


        [Get("/Employee/Get")]
        Task<Employee> GetEmployee(int id);


        [Post("/Employee/Post")]
        Task<string> CreateEmployee([Body] Employee emp);


        [Put("/Employee/Put")]
        Task<string> UpdateEmployee(int id, [Body] Employee emp);


        [Delete("/Employee/Delete")]
        Task<string> DeleteEmployee(int id);
    }
}
