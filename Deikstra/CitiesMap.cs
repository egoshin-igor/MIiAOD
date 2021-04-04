using System.Collections.Generic;

namespace Deikstra
{
    public class CitiesMap
    {
        private readonly DistanceMapContainer _distanceMap;

        public CitiesMap( DistanceMapContainer distanceMap )
        {
            _distanceMap = distanceMap;
        }

        public MinDistanceResult GetMinDistance( long fromCity, long toCity )
        {
            var calculator = new CitiesMinDistanceCalculator( _distanceMap, fromCity, toCity );
            return calculator.GetMinDistance();
        }
    }
}
