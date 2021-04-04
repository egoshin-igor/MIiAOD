using System.Collections.Generic;
using System.IO;

namespace Deikstra
{
    public class CitiesMapParser
    {
        public static CitiesMapParseResult Parse( string fileUri )
        {
            using ( var streamReader = new StreamReader( fileUri ) )
            {
                string citiesInfo = streamReader.ReadLine();
                string[] citiesInfoParts = citiesInfo.Trim().Split( " " );
                (long citiesCount, long roadsCount) = (long.Parse( citiesInfoParts[ 0 ] ), long.Parse( citiesInfoParts[ 1 ] ));
                (long startCity, long endCity) = (long.Parse( citiesInfoParts[ 2 ] ) - 1, long.Parse( citiesInfoParts[ 3 ] ) - 1);

                var distanceMap = new DistanceMapContainer( citiesCount );
                for ( int i = 0; i < roadsCount; i++ )
                {
                    string[] cityDistanceParts = streamReader.ReadLine().Trim().Split( " " );
                    (long from, long to) = (long.Parse( cityDistanceParts[ 0 ] ) - 1, long.Parse( cityDistanceParts[ 1 ] ) - 1);
                    long distance = long.Parse( cityDistanceParts[ 2 ] );
                    distanceMap.Add( from, to, distance );
                    distanceMap.Add( to, from, distance );
                }

                return new CitiesMapParseResult(
                   new CitiesMap( distanceMap ),
                   startCity,
                   endCity );
            }
        }
    }
}
