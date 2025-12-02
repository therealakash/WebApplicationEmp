using Microsoft.EntityFrameworkCore;
using WebApplicationEmpProject.Models;
using WebApplicationEmpProject.Repositry;

namespace WebApplicationEmpProject.Services
{
    public class Servie : IServices
    {
        private readonly Appdbcontext cnt;

        public Servie(Appdbcontext cnt)
        {
            this.cnt = cnt;
        }
        public async Task<Employee> AddAsync(Employee employee)
        {
            await cnt.AddAsync(employee);
            await cnt.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteAsync(int id)
        {
           var ed = await cnt.Employees.FindAsync(id);
            if (ed == null)
            {
                return null;
            }
            cnt.Employees.Remove(ed);
            await cnt.SaveChangesAsync();
            return ed;

        }

        public async Task<List<Employee>> GetAllAsync()
        {
             var els=await cnt.Employees.ToListAsync();
            return els;
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            var dd = await cnt.Department.ToListAsync();
            return dd;

        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            Employee? dd = await cnt.Employees.SingleOrDefaultAsync(x => x.Id == id);
            return dd;
        }

        public async Task<Employee> UpdateAsync(int id, Employee employee)
        {
            if(id!= employee.Id)
            {
                return null;
            }
            var ee = await cnt.Employees.SingleOrDefaultAsync(q=>q.Id == id);
            if (ee == null)
            {
                return null;
            }
            cnt.Entry(ee).CurrentValues.SetValues(employee);
            await cnt.SaveChangesAsync();
            return ee;
        }
    }
}
