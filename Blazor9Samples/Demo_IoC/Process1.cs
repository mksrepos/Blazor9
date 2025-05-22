namespace Demo_IOC;

internal class Process1
{

    // Demo of Control
    // the method controls what to call, and how to call it.
    internal void DoSomething()
    {
        Process1.Step1();
        Process1.Step2();
        Process1.Step3();
    }

    private static void Step1()
    {
        Console.WriteLine("-- step 1");
    }

    private static void Step2()
    {
        Console.WriteLine("-- step 2");
    }

    private static void Step3()
    {
        Console.WriteLine("-- step 3");
    }
}