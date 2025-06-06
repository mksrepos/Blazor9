using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWebappOnlyServer.Models;


[Table( name: "Employees", Schema = "hr" )]
public class Employee
{
    [Key]
    [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
    public int EmployeeId { get; set; }

    [Display( Name = "Employee Name" )]
    [Required( AllowEmptyStrings = false, ErrorMessage = "{0} cannot be empty" )]
    [StringLength( maximumLength: 50, MinimumLength = 2, ErrorMessage = "{0} must have {1} to {2} characters." )]
    public string EmployeeName { get; set; } = string.Empty;

    [Display( Name = "Designation" )]
    [StringLength( maximumLength: 30, MinimumLength = 2, ErrorMessage = "{0} must have {1} to {2} characters." )]
    public string? Designation { get; set; }


    [Display( Name = "Salary of Employee" )]
    [Required( AllowEmptyStrings = false, ErrorMessage = "{0} cannot be empty" )]
    [Range( minimum: 1.0, maximum: 100000f )]
    public decimal Salary { get; set; }

}
