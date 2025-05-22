using Microsoft.AspNetCore.Components;


namespace BlazorWebApp2.Components.Demo06Navigation;


public partial class EgNavigationLock
{

    private bool isSaved = false;


    [Inject]
    private NavigationManager _navigationManager { get; set; } = default!;


    private void ModalDemo()
    {
        DemoModal!.Show(accept: () =>
        {
            name = "Manoj Kumar Sharma";
            StateHasChanged();
        });
    }

    private void Save()
    {
        name = "";
        isSaved = true;
    }

    protected override void OnInitialized()
    {

        // ANOTHER WAY to handle this requirement,
        //  is to use the NavigationManager to register the LocationChanging event handler.
        // Unfortunately, this ALSO DOES NOT WORK.  Place a Breakpoint to check!
        // LocationChanged event handler is triggered once the location has changed.
        // RegisterLocationChangingHander is triggered when the location is changing before the location is changed.
        _navigationManager.RegisterLocationChangingHandler( (context) => 
        {
            return ValueTask.CompletedTask;
        });

        base.OnInitialized();
    }


    // NOTE: This is how the NavigationLock component would be implemented.
    //       Unfortunately, as stated earlier, this DOES NOT WORK.
    //public ValueTask OnLocationChanging( LocationChangingContext context )
    //{
    //    if (string.IsNullOrWhiteSpace(name) || context.HistoryEntryState is "leave")
    //    {
    //        return ValueTask.CompletedTask;
    //    }

    //    PreventModal!.Show(accept: () =>
    //    {
    //        name = "";

    //        _navigationManager.NavigateTo(
    //            context.TargetLocation,
    //            new NavigationOptions() { HistoryEntryState = "leave" }
    //        );
    //    });

    //    context.PreventNavigation();
    //    return ValueTask.CompletedTask;
    //}

}
