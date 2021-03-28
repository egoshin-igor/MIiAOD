namespace Deikstra
{
    public class CitiesMapParseResult
    {
        public CitiesMap Map { get; }
        public long StartCity { get; }
        public long EndCity { get; }

        public CitiesMapParseResult( CitiesMap map, long startCity, long endCity )
        {
            Map = map;
            StartCity = startCity;
            EndCity = endCity;
        }
    }
}
