using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp2.Pages;


public class Demo17Eg02RazorPageWithComponent : PageModel
{

    private readonly ILogger<Demo17Eg01RazorPageDemoModel> _logger;

    [BindProperty]
    public InputModel? Input { get; set; }


    [TempData]
    public string? StatusMessage { get; set; }


    public Demo17Eg02RazorPageWithComponent (
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
