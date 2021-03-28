using System;

namespace Deikstra
{
    class Program
    {
        static void Main()
        {
            CitiesMapParseResult parseResult = CitiesMapParser.Parse( "in.txt" );
            (long start, long end, CitiesMap map) = ( parseResult.StartCity, parseResult.EndCity, parseResult.Map );

            long minDistance = map.GetMinDistance( fromCity: start, toCity: end );
            Console.WriteLine(  );
        }
    }
}
