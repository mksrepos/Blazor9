using System;

namespace Demo_Destructor_FW
{
    internal class Employee
    {
        public int EmployeeId { get; set; }

        // public string? EmployeeName { get; set; }
        public string EmployeeName { get; set; } = string.Empty;

        ~Employee ()
        {
            Console.WriteLine( "--- {0} destroyed!", EmployeeName );
        }
    }


    /*
    class Demo
    {
        private void m ()
        {
            Employee emp = new Employee() { EmployeeName  = "Test" };
        }
    }
    */

}