using WebApplicationEmpProject.Models;

namespace WebApplicationEmpProject.Services
{
    public interface IServices
    {
        Task<Employee>AddAsync(Employee employee);
        Task<Employee>GetByIdAsync(int id);

        Task<List<Employee>> GetAllAsync();

        Task<Employee>UpdateAsync(int id, Employee employee);

        Task<Employee>DeleteAsync(int id);

        Task<List<Department>> GetAllDepartmentsAsync();
    }
}
