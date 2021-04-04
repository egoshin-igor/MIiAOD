using System.Collections.Generic;

namespace Deikstra
{
    public class DistanceMapContainer
    {
        private readonly Dictionary<long, Dictionary<long, long>> _source;

        public long CitiesCount { get; }

        public DistanceMapContainer( long citiesCount )
        {
            _source = new Dictionary<long, Dictionary<long, long>>();
            CitiesCount = citiesCount;
        }

        public void Add( long from, long to, long distance )
        {
            Dictionary<long, long> fromMap = _source.GetValueOrDefault( from );
            if ( fromMap == null )
            {
                fromMap = new Dictionary<long, long>();
                _source[ from ] = fromMap;
            }

            fromMap[ to ] = distance;
        }

        public long GetDistance( long from, long to )
        {
            Dictionary<long, long> fromMap = _source.GetValueOrDefault( from );
            return fromMap.GetValueOrDefault( to );
        }

        public Dictionary<long, long> GetRoadsFromCity( long cityFrom )
        {
            return _source.GetValueOrDefault(cityFrom) ?? new Dictionary<long, long>();
        }
    }
}
