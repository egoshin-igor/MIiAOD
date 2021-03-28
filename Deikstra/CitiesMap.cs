using System.Collections.Generic;
using Deikstra.BinaryHeap;

namespace Deikstra
{
    public class CitiesMap
    {
        private readonly BinaryHeap<CityDistance> _heap;
        private readonly Dictionary<long, CityDistance> _cityDistanceByCityNumber;
        private readonly HashSet<long> _minDistanceCities;

        private readonly long _startCity;
        private readonly long _endCity;
        private readonly long[,] _distanceMap;

        public long CitiesCount { get; }
        public long RoadCounts { get; }

        public CitiesMap(
            long citiesCount,
            long roadCounts,
            long[,] distanceMap )
        {
            CitiesCount = citiesCount;
            RoadCounts = roadCounts;

            _distanceMap = distanceMap;

            _heap = new BinaryHeap<CityDistance>();
            _cityDistanceByCityNumber = new Dictionary<long, CityDistance>();
            _minDistanceCities = new HashSet<long>();
        }

        public long GetMinDistance( long fromCity, long toCity )
        {
            var calculator = new CitiesMinDistanceCalculator( _distanceMap, fromCity, toCity );
            return calculator.GetMinDistance();
        }
    }
}
