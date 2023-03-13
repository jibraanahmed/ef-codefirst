using System.ComponentModel.DataAnnotations;

namespace CodeFirst_EF.Models
{
    public class Departments
    {
        [Key]
        public int DeptID { get; set; }
        public string? DeptName { get; set; }
        public int DeptStaffCount { get; set; }
        public double DeptBudget { get; set; }
    }
}
