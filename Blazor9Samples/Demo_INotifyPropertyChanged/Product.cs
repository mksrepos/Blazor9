using System.ComponentModel;

namespace Demo_INotifyPropertyChanged;

internal class Product
    : System.ComponentModel.INotifyPropertyChanged
{
    public int Id { get; set; }

    public string Name { get; set; }

    private int _quantity;
    public int Quantity
    {
        get
        {
            return _quantity;
        }
        set
        {
            _quantity = value;

            //if ( PropertyChanged is not null )
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Quantity)));
            //}
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Quantity)));
        }
    }

    #region System.ComponentModel.INotifyPropertyChanged members

    public event PropertyChangedEventHandler? PropertyChanged;

    #endregion

}
