using BlazorWebApp2.ViewModels;
using Bogus;

namespace BlazorWebApp2.Services.BogusGenerators;


public class BogusPersonService
{

    private Faker<PersonViewModel>? _fakerGenerator;


    public List<PersonViewModel> GeneratePeople( int count = 50 )
    {

        var countries = new[] { "India", "United States of America", "Canada", "Australia" };

        if (count < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than 1");
        }

        _fakerGenerator ??= new Faker<PersonViewModel>(locale: "en")
                // define a Seed Value to ensure that the seed data is generated each time the application is run
                .UseSeed(1970)

                // ensure all properties have rules (Default is "false")
                .StrictMode(true) 

                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.LastName, f => f.Person.LastName)
                .RuleFor(p => p.City, f => f.Person.Address.City)
                .RuleFor(p => p.State, f => f.Person.Address.State)

                // provide a zip code for 50% of the generated data
                .RuleFor(p => p.ProvinceZipCode, f => f.Person.Address.ZipCode.OrNull(f, 0.5f))

                // pick a random country from the list of countries
                .RuleFor(p => p.Country, f => f.PickRandom(countries) );

        return _fakerGenerator is not null
                ? _fakerGenerator.Generate(count)
                : [];                               // new List<ProductViewModel>()
    }


}

