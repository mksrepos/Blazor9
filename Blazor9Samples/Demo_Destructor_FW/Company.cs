using System;
using System.Collections.Generic;


// NOTE: 
//      You need to explicitly add the Nullablity Check Compiler Directive
//      to enable support for declaring Nullable type members.  Check out the Warning if you comment out this line.
#nullable enable

namespace Demo_Destructor_FW
{

    // STEPS to Implement the IDisposable interface
    // 1. Implement the interface IDisposable
    // 2. Moved all code from Destructor to Dispose()
    // 3. Call the Dispose() method when required
    // 4. Add a flag, and change its state in the Dispose() method.
    // 5. In EVERY METHOD (including Dispose), check if the object is Disposed using the flag
    //      => throw ObjectDisposedException
    // 6. In EVERY PROPERTY ACCESSOR, check if the object is Disposed using the flag
    //      => throw ObjectDisposedException
    // BENEFITS
    // a. You can now use the USING BLOCK to manage the Resource
    // b. You can also Suppress the Finalization (suppress call of Destructor) in the Dispose() method.
    internal class Company
        : System.IDisposable
    {
        private int newId;
        private List<Employee>? employees;              // aggregated object

        private string _companyName = string.Empty;
        public string CompanyName
        {
            get
            {
                if ( isDisposed )
                {
                    throw new ObjectDisposedException(
                        objectName: $"{CompanyName}",
                        message: "The Company has already been disposed!" );
                }

                return _companyName;
            }
            private set
            {
                _companyName = value;
            }
        }

        public Company ( string companyName )
        {
            CompanyName = companyName;
            newId = 0;

            isDisposed = false;
        }

        public void AddEmployee ( string newEmployeeName )
        {
            if( isDisposed )
            {
                throw new ObjectDisposedException( 
                    objectName: $"{CompanyName}", 
                    message: "The Company has already been disposed!");
            }

            // Late-Instantiation Pattern
            if ( employees is null )
            {
                employees = new List<Employee>();
            }
            Employee newEmployee = new Employee() { EmployeeId = ++newId, EmployeeName = newEmployeeName };
            employees.Add( newEmployee );
        }

        public void DisplayInfo ()
        {
            if ( isDisposed )
            {
                throw new ObjectDisposedException(
                    objectName: $"{CompanyName}",
                    message: "The Company has already been disposed!" );
            }

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

        private bool isDisposed; 

        public void Dispose()
        {
            if ( isDisposed )
            {
                throw new ObjectDisposedException(
                    objectName: $"{CompanyName}",
                    message: "The Company has already been disposed!" );
            }

            employees = null;
            Console.WriteLine( "Company {0} DISPOSED", CompanyName );

            isDisposed = true;

            // enforces that the Destructor does not have to be called, when the GC collects!
            System.GC.SuppressFinalize( this );
        }

        #endregion
 
        
        ~Company ()
        {
            // MOVE ALL CODE FROM DESTRUCTOR TO Dispose()
            // employees = null;


            Console.WriteLine( "Company {0} destroyed", CompanyName );
        }
    }

}