using System.Collections.Generic;
using Deikstra.BinaryHeap;

namespace Deikstra
{
    public class CitiesMinDistanceCalculator
    {
        private readonly BinaryHeap<CityDistance> _heap;
        private readonly Dictionary<long, CityDistance> _cityDistanceByCityNumber;
        private readonly HashSet<long> _minDistanceCities;
        private readonly long[,] _distanceMap;
        private readonly long _fromCity;
        private readonly long _toCity;

        public CitiesMinDistanceCalculator( long[,] distanceMap, long fromCity, long toCity )
        {
            _distanceMap = distanceMap;
            _fromCity = fromCity;
            _toCity = toCity;

            _heap = new BinaryHeap<CityDistance>();
            _cityDistanceByCityNumber = new Dictionary<long, CityDistance>();
            _minDistanceCities = new HashSet<long>();
        }

        public long GetMinDistance()
        {
            return 100;
        }
    }
}
