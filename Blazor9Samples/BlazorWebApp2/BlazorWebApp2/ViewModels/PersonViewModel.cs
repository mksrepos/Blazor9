namespace BlazorWebApp2.ViewModels;


public class PersonViewModel
{
    public Guid Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string City { get; set; }

    public required string State { get; set; }

    public string? ProvinceZipCode { get; set; }


    public required string Country { get; set; }

}
