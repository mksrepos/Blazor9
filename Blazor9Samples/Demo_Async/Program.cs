// See https://aka.ms/new-console-template for more information


// Example of how to call an Asynchronous method inside a Synchronous method
Demo01();
Console.WriteLine();

Demo02();

Demo03();

static void Demo01()
{
    Task<int> t = Task.Run( () => 10 );                     // return 10

    // Wait for the task to complete 
    t.Wait();

    if ( t.IsCompleted )
    {
        // Receive the result
        int retValue = t.Result;
        Console.WriteLine( "Received {0}", retValue );
    }
    else if ( t.IsFaulted )
    {
        Console.WriteLine( "Something went wrong" );
    }

    // in one single statement
    int retValue2 = Task.Run( () => 10 ).Result;
    Console.WriteLine( "Received {0}", retValue2 );

    // To Discard the returned value after completing the task.
    _ = t.Result;
}



static void Demo02 ()
{
    var retValue2 = Task.Run( async () => await DoSomethingAsync() ).Result;

    Console.WriteLine( "Received {0}", retValue2 );
}


static void Demo03 ()
{
    // Receive the result
    var t = Task.Run( async () => await DoSomethingAsync() );

    t.Wait();

    if ( t.IsCompletedSuccessfully )
    {
        int retValue = t.Result;
        Console.WriteLine( "Received {0}", retValue );
    }

}


static async ValueTask<int> DoSomethingAsync()
{
    await Task.Delay( 1000 );

    return 100;
}
