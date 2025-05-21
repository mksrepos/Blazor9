﻿using System.ComponentModel.DataAnnotations;


namespace BlazorWebApp2.Components.Demo04Misc.Models;


/// <remarks>
///     The Options pattern is a design pattern to manage and load configurations in an application.
///     It facilitates a way to build strongly typed configurations, and offers additional features
///     like validation, default values, reloading, etc.
/// 
///     This class is used to help understand how to use and leverage the OPTIONS PATTERN.
///     The class is registered in the application's services container, for Dependency Injection (DI). 
/// </remarks>
public class MyAppOptionsModel
{

    [Required(AllowEmptyStrings = false)]
    public string? CompanyName { get; set; }


    [Required(AllowEmptyStrings = false)]
    public string? TrainerName { get; set; }

    [Display(Name = "Trainer ID")]
    [Range(minimum: 1000, maximum: 50000, ErrorMessage = "{0} should be between {1} and {2}")]
    public int? TrainerId { get; set; } = null;

}
