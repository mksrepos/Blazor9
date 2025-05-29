using Demo_IDisposable;

// NOTE: I have upgraded the Language Version in the CSPROJ file
// <LangVersion>9.0</LangVersion>

Demo("Microsoft");

Console.WriteLine();

Demo("IBM");

Console.WriteLine();

Console.WriteLine( "---- exiting Main()" );
static void Demo(string companyname)
{
    Company? objCompany = new Company( companyname );

    objCompany.AddEmployee( "First Employee of "+ companyname );
    objCompany.AddEmployee( "Second Employee of " + companyname );
    objCompany.AddEmployee( "Third Employee of "+ companyname );
    objCompany.AddEmployee( "Fourth Employee of "+ companyname );

    objCompany.DisplayInfo();

    objCompany = null;
}
