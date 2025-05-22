using BlazorWebApp2.ViewModels;
using Bogus;

namespace BlazorWebApp2.Services.BogusGenerators;


public class BogusProductService
{

    private Faker<ProductViewModel>? _fakerGenerator;


    public List<ProductViewModel> GenerateProducts( int count = 10 )
    {
        if (count < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than 1");
        }

        //if (_fakerGenerator is null)
        //{
        //    _fakerGenerator = new Faker<ProductViewModel>(locale: "en")
        //        .UseSeed(1970)
        //        .RuleFor(p => p.Id, f => f.IndexFaker)
        //        .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())
        //        .RuleFor(p => p.ProductCategory, f => f.Commerce.Categories(1)[0]);
        //}

        _fakerGenerator ??= new Faker<ProductViewModel>(locale: "en")

            // define a Seed Value to ensure that the seed data is generated each time the application is run
            .UseSeed(1970)

            // Ensure that ID is deterministic (using a counter, or using built-in faker)
            .RuleFor(p => p.Id, f => f.IndexFaker)  

            .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())

            // pick the first category from the list of categories
            .RuleFor(p => p.ProductCategory, f => f.Commerce.Categories(1)[0]);

        return _fakerGenerator is not null
                ? _fakerGenerator.Generate(count)
                : [];                               // new List<ProductViewModel>()
    }

}

