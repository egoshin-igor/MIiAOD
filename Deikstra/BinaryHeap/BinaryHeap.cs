using System;
using System.Collections.Generic;
using System.Linq;

namespace Deikstra.BinaryHeap
{
    public class BinaryHeap<T> : IBinaryHeap<T>
        where T: class, IBinaryHeapItem<T>
    {
        private readonly List<T> _items;

        public BinaryHeap()
        {
            _items = new List<T>();
        }

        public void Add( T item )
        {
            _items.Add( item );
            int index = _items.Count - 1;
            while ( index > 0 && GetFather( index ).IsGreaterThan( _items[ index ] ) )
            {
                int fatherIndex = GetFatherIndex( index );
                ( _items[ index ], _items[ fatherIndex ]) = (_items[ fatherIndex ], _items[ index ]);
                index = fatherIndex;
            }
        }

        public T Pop()
        {
            if ( !_items.Any() )
            {
                return null;
            }

            // Сохраняем для возврата вершины
            T result = _items.First();

            // А последний элемент ставим в начало и удаляем
            _items[ 0 ] = _items.Last();
            _items.RemoveAt( _items.Count - 1 );

            KeepHeapAlive( 0 );

            return result;
        }

        private T GetFather( int currentIndex )
        {
            return _items[ GetFatherIndex( currentIndex ) ];
        }

        private int GetFatherIndex( int currentIndex )
        {
            return ( currentIndex + 1 ) / 2 - 1;
        }

        private void KeepHeapAlive( int index )
        {
            int leftIndex = index * 2 + 1;
            int rightIndex = leftIndex + 1;
            int lowerIndex = index;
            if ( leftIndex < _items.Count && _items[ lowerIndex ].IsGreaterThan( _items[ leftIndex ] ) )
            {
                lowerIndex = leftIndex;
            }
            if ( rightIndex < _items.Count && _items[ lowerIndex ].IsGreaterThan( _items[ rightIndex ] ) )
            {
                lowerIndex = rightIndex;
            }
            if ( lowerIndex != index )
            {
                (_items[ index ], _items[ lowerIndex ]) = (_items[ lowerIndex ], _items[ index ]);
                KeepHeapAlive( lowerIndex );
            }
        }
    }
}
