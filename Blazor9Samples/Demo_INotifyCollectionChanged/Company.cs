using System.Collections;

using System.Collections.Specialized;
using System.ComponentModel;

namespace Demo_INotifyCollectionChanged;


internal class Company
    : System.Collections.IEnumerable, 
      System.ComponentModel.INotifyPropertyChanged,
      System.Collections.Specialized.INotifyCollectionChanged
{
    private List<Employee>? _employees;


    #region System.ComponentModel.INotifyPropertyChanged members

    public event PropertyChangedEventHandler? PropertyChanged;

    #endregion

    #region System.Collections.Specialized.INotifyCollectionChanged members

    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    #endregion


    private string _companyName;

    public string CompanyName
    {
        get
        {
            return _companyName;
        }
        private set
        {
            if(this.PropertyChanged is not null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(CompanyName)));
            }
            _companyName = value;
        }
    }


    public Company(string companyName)
    {
        _companyName = companyName;
        _employees = null;                              // defer/postponing the instantion of the object
    }


    public void Add(Employee newEmployee)
    {
        // Late-Instation Pattern: instantiate only when really required.
        //if(_employees is null)
        //{
        //    _employees = new List<Employee>();
        //}
        // _employees ??= new List<Employee>();
        _employees ??= [];      // C# 9.0 onwards


        _employees.Add(newEmployee);


        // check if event is subscribed
        if (this.CollectionChanged is not null)
        {
            // Raise the event!
            this.CollectionChanged(
                sender: this,                                           // whose collection got changed.
                e: new NotifyCollectionChangedEventArgs(
                    action: NotifyCollectionChangedAction.Add,          // what action was done on the collection (e.Action)
                    changedItem: newEmployee));                         // which object was impacted (in e.NewItems)
        }
    }

    public void Remove(Employee existingEmployee)
    {
        // Late-Instantion Pattern: check before consumption
        if (_employees is not null)
        {
            _employees.Remove(existingEmployee);

            // check if event is subscribed
            if (this.CollectionChanged is not null)
            {
                // Raise the event!
                this.CollectionChanged(
                    this,                                           // whose collection got changed.
                    new NotifyCollectionChangedEventArgs(
                        NotifyCollectionChangedAction.Remove,       // what action was done on the collection (e.Action)
                        existingEmployee));                         // which object was impacted (in e.OldItems)
            }
        }
    }



    // Indexer
    public Employee? this[string nameOfEmployeeToFind]
    {
        get
        {
            if (_employees is null)
            {
                return null;
            }

            Employee? empFound = null;
            foreach (Employee emp in _employees)
            {
                if(emp.Name == nameOfEmployeeToFind)
                {
                    empFound = emp;
                    break;
                }
            }

            Employee? empFound2 = (from e in _employees
                                  where e.Name == nameOfEmployeeToFind
                                  select e).FirstOrDefault();

            Employee? empFound3 = _employees.FirstOrDefault(e => e.Name == nameOfEmployeeToFind);

            return empFound;
        }
    }


    #region System.Collections.IEnumerable members

    public IEnumerator GetEnumerator()
    {
        // Late-Instation Pattern: Check before usage!
        if (_employees is not null)
        {
            foreach (Employee employee in _employees)
            {
                yield return employee;
            }
        }
        else
        {
            yield break;
        }
    }

    #endregion

}
