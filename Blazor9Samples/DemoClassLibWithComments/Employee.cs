namespace DemoClassLibWithComments;

// Configure the BUILD -> OUTPUT -> Generate Documentation File


/// <summary>
///     Creates an object of Employee
/// </summary>
public class Employee
{

    /// <summary>
    ///     Gets the Id of the Employee
    /// </summary>

    public int Id { get; private set; }

    
    /// <summary>
    ///     Gets or Sets the Name of the Employee
    /// </summary>
    public string? Name { get; set; }



    /// <summary>
    ///     Promote the employee
    /// </summary>
    /// <param name="newSalary">the new salary after promotion</param>
    /// <returns>true if successful, false if not</returns>
    /// <exception cref="InvalidOperationException">Reason for failure while promoting the employee</exception>
    /// <seealso cref="System.Console.WriteLine(string?)" />
    /// <example>
    ///     Employee emp = new ();
    ///     emp.Promote(100M, "CEO");
    /// </example>
    public bool Promote (decimal newSalary)
    {
        bool isSuccessful = false;

        if (Id != 5)
        {
            Console.WriteLine( "something happened wrong here" );
            throw new InvalidOperationException( "Unable to promote this employee!" );
        }

        isSuccessful = true;
        return isSuccessful;
    }


    /// <summary>
    ///     Promote the employee
    /// </summary>
    /// <param name="newDesignation">the new designation</param>
    /// <param name="newSalary">the new salary after promotion</param>
    /// <returns>true if successful, false if not</returns>
    /// <exception cref="InvalidOperationException">Reason for failure while promoting the employee</exception>
    /// <seealso cref="System.Console.WriteLine(string?)" />
    public bool Promote ( decimal newSalary, string newDesignation )
    {
        bool isSuccessful = false;

        if ( Id != 5 )
        {
            Console.WriteLine("something happened wrong here");
            throw new InvalidOperationException( "Unable to promote this employee!" );
        }

        isSuccessful = true;
        return isSuccessful;
    }

}


class X
{
    private void demo ()
    {
        Employee emp = new Employee();
        emp.Promote( 1000M, "CEO" );
    }
}