namespace Demo_Func
{
    class Demo1
    {
        //delegate int RandomHandler();
        // Func<int> getRandomNumber;                // same as above

        // delegate int DoSomething(string message);
        // Func<int, string> DoSomething;

        public static void RunThis()
        {
            Func<int> getRandomNumber = delegate ()
            {
                Random randomizer = new Random();
                System.Threading.Thread.Sleep(500);     // 1000 millisecond = 1 second
                return randomizer.Next(1, 10);
            };

            Console.WriteLine("Random Number between 1 and 10: {0} ", getRandomNumber());
            Console.WriteLine("Random Number between 1 and 10: {0} ", getRandomNumber());
            Console.WriteLine("Random Number between 1 and 10: {0} ", getRandomNumber());
            Console.WriteLine("Random Number between 1 and 10: {0} ", getRandomNumber());
            Console.WriteLine("Random Number between 1 and 10: {0} ", getRandomNumber());
            Console.WriteLine("Random Number between 1 and 10: {0} ", getRandomNumber());
            Console.WriteLine("Random Number between 1 and 10: {0} ", getRandomNumber());
            Console.WriteLine("Random Number between 1 and 10: {0} ", getRandomNumber());
        }
    }
}
