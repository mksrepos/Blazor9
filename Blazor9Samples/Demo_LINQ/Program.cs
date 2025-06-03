int[] arr = { 78, 99, 88, 63, 55, 48, 36, 25, 27, 30, 36, 40, 46, 45 };

// between 27 and 60
int length = arr.Length;
for(int i = 0 ; i < length ; i++ )
{
    // if ( arr[i] >= 27 && <= 60 )
    // if ( (arr[i] > 27 || arr[i] == 27)
    //     && (arr[i] < 60  || arr[i] == 60) )

    int j = arr[i];
    if ( j > 26 && j < 61 )
    {
        Console.Write( "{0} ", j );
    }
}
Console.WriteLine();


foreach( int i in arr )
{
    if ( i > 26 && i < 61 )
    {
        Console.Write( "{0} ", i);
    }
}
Console.WriteLine();

int[] arrCopy = (int[]) arr.Clone() ;
Array.Sort( arrCopy );
arrCopy = arrCopy.Reverse().ToArray();
foreach ( int i in arrCopy )
{
    if ( i > 26 && i < 61 )
    {
        Console.Write( "{0} ", i );
    }
}
Console.WriteLine();


// LINQ
var query = from i in arr
            where i > 26 && i < 61              // .Where( i => i > 26 && i < 61 )
            orderby i descending                // .OrderByDescending( i => i )
            select i;                           // .Select(i => i).ToArray()
foreach ( int i in query )
{
    Console.Write( "{0} ", i );
}
Console.WriteLine();

// LAMBDA version 
var query2 = arr.Where( i => i > 26 && i < 61 )
                .OrderByDescending( i => i )
                .ToArray();
foreach ( int i in query2 )
{
    Console.Write( "{0} ", i );
}
Console.WriteLine();
