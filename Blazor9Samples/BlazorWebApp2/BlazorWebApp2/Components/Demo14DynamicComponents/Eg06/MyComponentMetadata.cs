namespace BlazorWebApp2.Components.Demo14DynamicComponents.Eg06;

/// <summary>
///     Represents the Metadata needed for the Parameters sent into the Dynamic Component.
/// </summary>
public class MyComponentMetadata
{

    // This will be the Dictionary Item's Key
    public required Type Type { get; init; }


    // This would be the name by which the dynamically loaded component would be identified by the user.
    public required string Name { get; init; }

    
    // This will be the Dictionary Item's Value
    // The first item in this dictionary would be the ComponentType,
    //      optionally followed by the key/value pair for each of the fields shown in the components.
    public Dictionary<string, object> Parameters { get; } = [];

}
