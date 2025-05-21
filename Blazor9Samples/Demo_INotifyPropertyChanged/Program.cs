using Demo_INotifyPropertyChanged;
using System.ComponentModel;


// Need to set the Console.OutputEncoding to UTF8 to display the currency symbol from the OS Region settings.
Console.OutputEncoding = System.Text.Encoding.UTF8;

List<Employee> employees = [
    new Employee(1, 100M) { Name = "First Employee", Designation = "desig1" },
    new Employee(2, 2500M) { Name = "Second Employee", Designation = "desig2" },
    new Employee(3, 13000M) { Name = "Third Employee", Designation = "desig3" },
    new Employee(4, 650000M) { Name = "Fourth Employee", Designation = "desig4" },
    new Employee(5, 3550M) { Name = "Fifth Employee", Designation = "desig5" },
];

foreach (Employee emp in employees)
{
    Console.WriteLine("{0} {1,-20} {2,15:C} {3,-20}", emp.Id, emp.Name, emp.Salary, emp.Designation);
}
Console.WriteLine();

//---  Subscribing to the Event for the SECOND EMPLOYEE
employees[1].PropertyChanged += new PropertyChangedEventHandler(Employee_PropertyChanged);
employees[1].PropertyChanged += Employee_PropertyChanged;


//--- Bind/Subscribe to the event to all the employee objects in the collection!
foreach (Employee emp in employees)
{
    emp.PropertyChanged += ( sender, e ) =>
    {
        Employee? emp = sender as Employee;
        Console.WriteLine($"------ NOTE: {e.PropertyName} of Employee ID {emp?.Id} was changed!");
    };
}

Console.WriteLine("---- Promoting couple of employees");
employees[1].Promote("CEO");             // second employee
employees[3].Promote("Manager");         // fourth employee
Console.WriteLine();

foreach (Employee emp in employees)
{
    Console.WriteLine("{0} {1,-20} {2,15:C} {3,-20}", emp.Id, emp.Name, emp.Salary, emp.Designation);
}
Console.WriteLine();






static void Employee_PropertyChanged( object? sender, PropertyChangedEventArgs e )
{
    Employee? emp = sender as Employee;
    if (emp is not null)
    {
        Console.WriteLine($"------ NOTE: {e.PropertyName} of Employee ID {emp.Id} was changed!");
    }
}

