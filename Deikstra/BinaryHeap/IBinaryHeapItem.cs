namespace Deikstra.BinaryHeap
{
    public interface IBinaryHeapItem<T> where T: class
    {
        bool IsGreaterThan( T binaryHeapItem );
    }
}
