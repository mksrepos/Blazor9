namespace Demo_DI;

internal class GoldVersionProcess : IStepActivity
{
    public void Step1()
    {
        Console.WriteLine("-- gold version - step 1");
    }

    public void Step2()
    {
        Console.WriteLine("-- gold version - step 2");
    }

    public void Step3()
    {
        Console.WriteLine("-- gold version - step 3");
    }
}