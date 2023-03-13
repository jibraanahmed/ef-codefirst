using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst_EF.Models
{
    public class Employees
    {
        [Key]
        public int EmpID { get; set; }
        public string? EmpName { get; set; }
        public string? EmpDesignation { get; set; }
        public double EmpSalary { get; set; }
        [ForeignKey("DeptID")]
        public int DeptID { get; set; }
    }
}
