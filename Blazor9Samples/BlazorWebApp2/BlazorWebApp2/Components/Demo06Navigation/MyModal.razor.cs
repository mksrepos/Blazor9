using Microsoft.AspNetCore.Components;

namespace BlazorWebApp2.Components.Demo06Navigation;

public partial class MyModal
{
    private bool _isShown { get; set; }

    private Action _acceptAction { get; set; } = default!;


    [Parameter]
    public string Title { get; set; } = "";
    

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    
    public void Show(Action accept)
    {
        _acceptAction = accept;
        _isShown = true;
        StateHasChanged();
    }


    public void Close()
    {
        _isShown = false;
        StateHasChanged();
    }


    public void Accept()
    {
        _acceptAction();

        _isShown = false;
    }   

}
