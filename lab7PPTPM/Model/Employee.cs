using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab7PPTPM.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId {  get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeName { get; set; }
        public string? EmployeePatronymic {  get; set; }
        public string EmployeeLogin { get; set; }
        public string EmployeePassword { get; set; }
        [ForeignKey("PositionJob")]
        public int PositionJobId { get; set; }
        public Employee(int employeeId, string employeeSurname, string employeeName, string? employeePatronymic, string employeeLogin, string employeePassword, int positionJobId)
        {
            EmployeeId = employeeId;
            EmployeeSurname = employeeSurname;
            EmployeeName = employeeName;
            EmployeePatronymic = employeePatronymic;
            EmployeeLogin = employeeLogin;
            EmployeePassword = employeePassword;
            PositionJobId = positionJobId;
        }
        public Employee() { }
    }
}