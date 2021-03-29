namespace Deikstra
{
    public class DistancePath
    {
        public long Distance { get; private set; }
        public long BackCity { get; }

        public DistancePath( long distance, long backCity )
        {
            Distance = distance;
            BackCity = backCity;
        }

        public void ChangeDistance( long newDistance )
        {
            Distance = newDistance;
        }
    }
}
