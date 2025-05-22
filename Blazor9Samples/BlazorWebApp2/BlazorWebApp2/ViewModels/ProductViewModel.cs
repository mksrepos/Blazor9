namespace BlazorWebApp2.ViewModels;


public class ProductViewModel
{
    public int Id { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public required string ProductCategory { get; set; }

    public override string ToString() => $"{ProductName} [ {ProductCategory} ]";

}
