namespace Demo_IDisposable;

internal class Employee
    : IDisposable
{
    public int EmployeeId { get; set; }

    // public string? EmployeeName { get; set; }
    // public string EmployeeName { get; set; } = string.Empty;
    public required string EmployeeName { get; set; }


    ~Employee()
    {
        // Console.WriteLine( "--- Employee {0} destroyed!", this.EmployeeId );
    }

    public void Dispose ()
    {
        Console.WriteLine( "--- Employee {0} destroyed!", this.EmployeeId );
    }
}

