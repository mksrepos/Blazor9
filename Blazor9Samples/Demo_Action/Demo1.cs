namespace Demo_Action
{
    class Demo1
    {
        delegate void DoSomethingHandler(int i);

        public static void RunThis()
        {
            // Direct call
            DoSomething(10);

            // Calling through a delegate
            DoSomethingHandler objD = new DoSomethingHandler(Demo1.DoSomething);
            objD(20);

            // Calling through the delegate using an Anonymous Method
            DoSomethingHandler objD2 = 
                (i) => Console.WriteLine($"hello received: {i}");
            objD2(10);
        }

        static void DoSomething(int i)
        {
            Console.WriteLine($"do something called with {i}");
        }
    }
}
