// Inversion of Control (IoC) Demo

using Demo_IOC;

Console.WriteLine("--- demo of controlled code");
Process1 p = new Process1();
p.DoSomething();

Console.WriteLine();

Console.WriteLine("--- demo of IoC using Delegate (callback code)");
Process2 p2 = new Process2();
p2.DoSomething(X.MyCustomStep2);
Console.WriteLine();

Console.WriteLine("--- demo of IoC using Events");
Process2 p2b = new Process2();
p2b.eventHandler += () => {
    Console.WriteLine("called using Event");
};
p2b.DoSomethingByEvent();

// IoC using Events 
Console.WriteLine();

// IoC using Interface
Console.WriteLine("--- demo of IoC using Interface");
IStepActivity objGold = new GoldVersionProcess();
IStepActivity objSilver = new SilverVersionProcess();
Process3 p3 = new Process3();
p3.DoSomething(objSilver); // p3.DoSomething(objGold);
Console.WriteLine();


internal class X
{
    internal static void MyCustomStep2()
    {
        Console.WriteLine("--- customized step 2");
    }
}