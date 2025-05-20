using Demo_INotifyPropertyChanged;

Product product = new Product()
{
    Id = 1,
    Name = "First Product",
    Quantity = 10
};

product.Quantity = 50;

product.PropertyChanged += ( sender, e ) =>
{
    Console.WriteLine(e.PropertyName + " got changed. ");
};
product.Quantity += 10;
