using CodeFirst_EF.Contexts;
using CodeFirst_EF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace CodeFirst_EF.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly ORGContext context;
        public EmployeeController(ORGContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("/emp")]
        public async Task<ActionResult<List<Employees>>> GetRecords()
        {
            List<Employees> list = new List<Employees>();
            try
            {
                if (this.context != null)
                {
                    list = await this.context.Employees.ToListAsync();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            return list;
        }

        [HttpGet]
        [Route("/emp/{id}")]
        public async Task<ActionResult<Employees>> GetRecord(int id)
        {
            Employees EMP = new Employees();
            try
            {
                if (this.context != null)
                {
                    if (id > 0)
                    {
                        EMP = await this.context.Employees.Where(ex => ex.EmpID == id).FirstAsync();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            return EMP;
        }

        [HttpPost]
        [Route("/emp/save")]
        public async Task<ActionResult> InsertRecord(Employees EMP)
        {
            try
            {
                if (EMP.GetType() == typeof(Employees) && EMP != null)
                {
                    this.context.Add(EMP);
                    await this.context.SaveChangesAsync();

                    return CreatedAtAction(nameof(EMP), new { id = EMP.EmpID }, EMP);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("/emp/edit")]
        public async Task<ActionResult> UpdateRecord(Employees EMP)
        {
            try
            {
                if (EMP.GetType() == typeof(Employees) && EMP != null)
                {
                    var existS = this.context.Employees.SingleOrDefault(x => x.EmpID == EMP.EmpID);
                    if (existS != null)
                    {
                        existS.EmpName = EMP.EmpName;
                        existS.EmpDesignation = EMP.EmpDesignation;
                        existS.EmpSalary = EMP.EmpSalary;
                        await this.context.SaveChangesAsync();

                        return CreatedAtAction(nameof(existS), new { id = existS.EmpID }, existS);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("/emp/{id}")]
        public async Task<String> DeleteRecord(int id)
        {
            try
            {
                if (id > 0)
                {
                    var existS = this.context.Employees.SingleOrDefault(x => x.EmpID == id);
                    if (existS != null)
                    {
                        this.context.Remove(existS);
                        await this.context.SaveChangesAsync();
                        return "User deleted with ID: " + id;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            return "No user found for ID: " + id;
        }
    }
}
