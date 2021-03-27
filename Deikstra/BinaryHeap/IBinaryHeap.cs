namespace Deikstra.BinaryHeap
{
    public interface IBinaryHeap<T> where T: class, IBinaryHeapItem<T>
    {
        void Add( T item );
        T Pop();
    }
}
