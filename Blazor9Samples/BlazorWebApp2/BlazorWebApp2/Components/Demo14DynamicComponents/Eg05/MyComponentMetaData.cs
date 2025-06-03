namespace BlazorWebApp2.Components.Demo14DynamicComponents.Eg05;


/// <summary>
///     Represents the Metadata needed for the Parameters sent into the Dynamic Component.
/// </summary>
public class MyComponentMetadata
{

    // This will be the Dictionary Item's Key
    public Type? ComponentType { get; set; }


    // This will be the Dictionary Item's Value
    // The first item in this dictionary would be the ComponentType,
    //      optionally followed by the key/value pair for each of the fields shown in the components.
    public Dictionary<string, object>? ComponentParameters { get; set; }

}
