using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp2.Pages;


/********************************
 * 
 *  To enable support for Razor Pages in the Blazor WebApp, add the following in PROGRAM.CS file:
 * 
 *          builder.Services.AddRazorPages();
 *          
 *          ...
 *          
 *          app.MapRazorPages();
 *          
 *  You would also need to configure a Layout File and setup the default files in the PAGES folder
 *      _ViewStart.cshtml
 *      _ViewImports.cshtml
 **/


public class Demo17Eg01RazorPageDemoModel : PageModel
{

    private readonly ILogger<Demo17Eg01RazorPageDemoModel> _logger;

    [BindProperty]
    public InputModel? Input { get; set; }


    [TempData]
    public string? StatusMessage { get; set; }


    public Demo17Eg01RazorPageDemoModel (
        ILogger<Demo17Eg01RazorPageDemoModel> logger)
    {
        _logger = logger;
        Input = null;
    }

    public void OnGet()
    {
        Input = new() { Name = "Manoj Kumar Sharma" };
    }


    public void OnPost() 
    {
        if ( ModelState.IsValid )
        {
            StatusMessage = $"Hi, {Input?.Name}!  Nice to meet you.";
        }
    }


    public class InputModel
    {

        [Display(Name = "Your name")]
        [Required(ErrorMessage = "{0} cannot be empty")]
        [StringLength( maximumLength: 50, MinimumLength = 2, ErrorMessage = "{0} must be between {1} and {2} characters long.")]
        public string Name { get; set; } = string.Empty;
    }

}
