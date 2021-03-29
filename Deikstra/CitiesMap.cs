namespace Deikstra
{
    public class CitiesMap
    {
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
        }

        public MinDistanceResult GetMinDistance( long fromCity, long toCity )
        {
            var calculator = new CitiesMinDistanceCalculator( _distanceMap, fromCity, toCity );
            return calculator.GetMinDistance();
        }
    }
}
