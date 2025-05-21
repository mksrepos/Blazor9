using System.ComponentModel;


namespace Demo_INotifyPropertyChanged;

internal class Employee
    : INotifyPropertyChanged
{

    #region System.ComponenetModel.INotifyPropertyChanged members

    public event PropertyChangedEventHandler? PropertyChanged;

    #endregion



    public int Id { get; private set; }


    public string Name { get; set; } = String.Empty;

    
    private string _designation;
    public string Designation
    {
        get
        {
            return _designation;
        }
        set
        {
            //if(this.PropertyChanged is not null)
            //{
            //    this.PropertyChanged(this, new PropertyChangedEventArgs("Designation"));
            //}

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Designation)));
            _designation = value;
        }
    }


    private decimal _salary;
    public decimal Salary 
    {
        get
        {
            return _salary;
        }
        private set
        {
            if (this.PropertyChanged is not null)   // check if event is subscribed
            {
                //-- Raise the event
                // PropertyChangedEventArgs e = new PropertyChangedEventArgs("Salary");
                // this.PropertyChanged(this, e);
                this.PropertyChanged(this, new PropertyChangedEventArgs("Salary"));
            }

            _salary = value;
        }
    }


    public Employee(int id, decimal salary)
    {
        Id = id;
        _salary = salary;
        _designation = String.Empty;
    }


    public void Promote(string newDesignation)
    {
        this.Designation = newDesignation;
        this.Salary += (Salary * 0.20M);
        Console.WriteLine($"Promoted the Employee {this.Id} with a 20% Raise in the Salary");
    }

}
