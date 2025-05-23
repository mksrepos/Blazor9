namespace Demo_DI;

internal class Process4
{
    private IStepActivity _activity;

    // The Dependency is Injected during construction of the object
    internal Process4(IStepActivity activity)
    {
        _activity = activity;
    }

    internal void DoSomething()
    {
        _activity.Step1();
        _activity.Step2();
        _activity.Step3();
    }

    internal void DoSomethingElse()
    {
        _activity.Step1();
    }


    internal void DoDifferent()
    {
        _activity.Step1();
        _activity.Step3();
    }
}
