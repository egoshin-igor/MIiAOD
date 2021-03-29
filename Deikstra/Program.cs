using System;

namespace Deikstra
{
    class Program
    {
        static void Main()
        {
            CitiesMapParseResult parseResult = CitiesMapParser.Parse( "in.txt" );
            (long start, long end, CitiesMap map) = (parseResult.StartCity, parseResult.EndCity, parseResult.Map);

            MinDistanceResult result = map.GetMinDistance( fromCity: start, toCity: end );
            Console.WriteLine( result.MinDistance );
            Console.WriteLine( result.Path );
        }
    }
}
