using System.Collections.Generic;
using System.Text;
using Deikstra.BinaryHeap;

namespace Deikstra
{
    public class CitiesMinDistanceCalculator
    {
        private readonly BinaryHeap<CityDistance> _heap;
        /// <summary>
        /// Отражает текущее известное минимальное расстояние от стартового города до города по ключу
        /// </summary>
        private readonly Dictionary<long, DistancePath> _distancePathByCityNumber;
        /// <summary>
        /// Города с гарантированными минимальными расстояниями от стартового города
        /// </summary>
        private readonly HashSet<long> _minDistanceCities;

        private readonly long[,] _distanceMap;
        private readonly long _fromCity;
        private readonly long _toCity;

        private MinDistanceResult _result = null;

        public CitiesMinDistanceCalculator( long[,] distanceMap, long fromCity, long toCity )
        {
            _distanceMap = distanceMap;
            _fromCity = fromCity;
            _toCity = toCity;

            _heap = new BinaryHeap<CityDistance>();
            _distancePathByCityNumber = new Dictionary<long, DistancePath>();
            _minDistanceCities = new HashSet<long>();
        }

        public MinDistanceResult GetMinDistance()
        {
            if ( _result != null )
            {
                return _result;
            }

            _heap.Add( new CityDistance( _fromCity, _fromCity, 0 ) );

            while ( !_minDistanceCities.Contains( _toCity ) )
            {
                CityDistance currentCity = _heap.Pop();
                long currentCityIndex = currentCity.To;
                if ( currentCity == null )
                {
                    return MinDistanceResult.NotFound();
                }
                _minDistanceCities.Add( currentCityIndex );

                var citiesCount = _distanceMap.GetUpperBound( 0 );
                for ( long city = 0; city <= citiesCount; city++ )
                {
                    if ( _minDistanceCities.Contains( city ) )
                    {
                        continue;
                    }

                    if ( _distanceMap[ currentCityIndex, city ] == 0 )
                    {
                        continue;
                    }


                    long distance = _distanceMap[ currentCityIndex, city ] + currentCity.Distance;
                    long currentMinDistance = _distancePathByCityNumber.ContainsKey( city )
                        ? _distancePathByCityNumber[ city ].Distance
                        : long.MaxValue;
                    if ( distance < currentMinDistance )
                    {
                        _heap.Add( new CityDistance( currentCityIndex, city, distance ) );
                        _distancePathByCityNumber[ city ] = new DistancePath( distance, currentCityIndex );
                    }
                }
            }

            _result = new MinDistanceResult(
                _distancePathByCityNumber[ _toCity ].Distance,
                GetMinPath() );
            return _result;
        }

        private string GetMinPath()
        {
            var result = new StringBuilder();
            long currentIndex = _toCity;
            while ( currentIndex != _fromCity )
            {
                DistancePath path = _distancePathByCityNumber[ currentIndex ];
                result.Insert( 0, $" {currentIndex + 1}" );
                currentIndex = path.BackCity;
            }
            result.Insert( 0, ( _fromCity + 1 ).ToString() );

            return result.ToString();
        }
    }
}
