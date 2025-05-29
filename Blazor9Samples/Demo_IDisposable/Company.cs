namespace Demo_IDisposable;

internal class Company
    : System.IDisposable
{
    private int newId;
    private List<Employee>? employees;              // aggregated object

    public string CompanyName { get; private set; } 

    public Company(string companyName )
    {
        CompanyName = companyName;
        newId = 0;
    }

    public void AddEmployee (string newEmployeeName)
    {
        // Late-Instantiation Pattern
        if(employees is null)
        {
            employees = new List<Employee>();
        }
        Employee newEmployee = new Employee() { EmployeeId = ++newId,  EmployeeName = newEmployeeName };
        employees.Add( newEmployee );
    }

    public void DisplayInfo ()
    {
        if ( employees is not null )
        {
            Console.WriteLine( "Employees of Company: {0}", CompanyName.ToUpper() );
            foreach ( Employee emp in employees )
            {
                Console.WriteLine( "{0} {1}", emp.EmployeeId, emp.EmployeeName );
            }
        }
        else
        {
            Console.WriteLine( "No Employees exist in Company: {0}", CompanyName.ToUpper() );
        }
    }


    #region System.IDisposable members

    public void Dispose()
    {
        employees.Clear();
        employees = null;
    }

    #endregion
    ~Company () 
    {
        // MOVE ALL CODE FROM DESTRUCTOR TO Dispose()
        // employees = null;
    }
}
