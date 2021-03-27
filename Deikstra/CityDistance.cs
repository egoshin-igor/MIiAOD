using System;
using Deikstra.BinaryHeap;

namespace Deikstra
{
    public class CityDistance : IBinaryHeapItem<CityDistance>
    {
        public long From { get; }
        public long To { get; }
        public long Distance { get; }


        public CityDistance( long from, long to, long distance )
        {
            From = from;
            To = to;
            Distance = distance;
        }

        public bool IsGreaterThan( CityDistance binaryHeapItem )
        {
            return Distance > binaryHeapItem.Distance;
        }

        public override string ToString()
        {
            return $"{Distance}";
        }
    }
}
