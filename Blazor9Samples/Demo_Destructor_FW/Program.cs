﻿using System;

/*
 * NOTE:
 *      This is a .NET Framework Project.
 *      
 *      I have added the following lines to upgrade the C# Language Version, and enable nullable check:
 *          <LangVersion>9.0</LangVersion>
 *          <Nullable>enable</Nullable>
 *      
 *      Both above shown lines have been added below the following line in the .CSPROJ file:
 *          <TargetFrameworkVersion>v4.8.1</TargetFrameworkVersion>
 *          
 *      You might need to explicitly add the below shown Compiler Directive to enable nullability-check
 *      (for example, check out Company.cs)
 *          #nullable enable
 */


#nullable enable

namespace Demo_Destructor_FW
{
    internal class Program
    {
        static void Main ( string[] args )
        {
            Demo( "Microsoft" );

            Console.WriteLine();

            Demo( "IBM" );

            Console.WriteLine();

            Console.WriteLine( "---- exiting Main()" );


            ResourceManagedDemo();
        }


        static void Demo ( string companyname )
        {
            Company? objCompany = new Company( companyname );

            try
            {
                objCompany.AddEmployee( "First Employee of " + companyname );
                objCompany.AddEmployee( "Second Employee of " + companyname );
                objCompany.AddEmployee( "Third Employee of " + companyname );
                objCompany.DisplayInfo();

                objCompany.Dispose();
                objCompany.AddEmployee( "Fourth Employee of " + companyname );

                objCompany.DisplayInfo();

                // objCompany = null;
                objCompany.Dispose();
            }
            catch( ObjectDisposedException exp )
            {
                Console.WriteLine("OBJECT NAME: {0}", exp.ObjectName );
                Console.WriteLine("MESSAGE: {0}", exp.Message);
            }

            Console.WriteLine();
            Console.WriteLine(" Company Name after DISPOSE: {0}", objCompany.CompanyName );
        }


        static void ResourceManagedDemo()
        {
            string companyname = "CapGemini";

            using ( Company? objCompany = new Company( companyname ) )
            {
                objCompany.AddEmployee( "First Employee of " + companyname );
                objCompany.AddEmployee( "Second Employee of " + companyname );
                objCompany.AddEmployee( "Third Employee of " + companyname );
                objCompany.DisplayInfo();
            }               // implicitly calls the objCompany.Dispose() method
        }


    }
}
