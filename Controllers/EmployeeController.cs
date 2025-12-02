using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationEmpProject.Models;
using WebApplicationEmpProject.Services;

namespace WebApplicationEmpProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServices se;

        public EmployeeController(IServices se)
        {
            this.se = se;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var ek = await se.GetAllAsync();
            return Ok(ek);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmp(int id)
        {
            var ed = await se.GetByIdAsync(id);
            return Ok(ed);
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee emp)
        { var ekk = await se.AddAsync(emp);
            return CreatedAtAction(nameof(GetEmployees), new { id = ekk.Id }, emp);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmp(int id, Employee emp)
        {
            var empk = await se.UpdateAsync(id, emp);

            if (id != empk.Id)
            {
                return BadRequest();
            }
            if (empk == null)
            {
                return NotFound();

            }
            return Ok(empk);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var del = await se.DeleteAsync(id);
            if(del == null)
            {
                return NoContent();
            }
            return Ok(del);
        }

    }
}
