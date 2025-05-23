namespace Demo_IOC;

delegate void StepHandler();

internal class Process2
{

    internal event StepHandler? eventHandler;

    internal void DoSomethingByEvent()
    {
        Process2.Step1();
        eventHandler?.Invoke();
        Process2.Step3();
    }

    // Inversion of Control (IoC) using Delegate
    // the invoker of DoSomething controls which code to call (invoke)
    internal void DoSomething(StepHandler objD)
    {
        Process2.Step1();

        //if (objD is not null)
        //{
        //    objD();
        //}

        objD?.Invoke();

        Process2.Step3();
    }

    private static void Step1()
    {
        Console.WriteLine("-- step 1");
    }

    private static void Step3()
    {
        Console.WriteLine("-- step 3");
    }
}