using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aho
{
    class AhoAutomat
    {
        private Bohr _root;
        private Bohr _current;

        public AhoAutomat()
        {
            _root = new Bohr( char.MinValue );
            _current = _root;
        }

        public IReadOnlyList<string> GetCurrentEntries()
        {
            var result = new List<string>();
        
            if ( _current.IsComplete )
            {
                result.Add( GetStringFromBohr( _current ) );
            }

            Bohr current = _current.GetGoodSuffLink();
        
            while (current != _root) {
                result.Add( GetStringFromBohr( current ) );
                current = current.GetGoodSuffLink();
            }

            return result;
        }

        public void AddEnrty( string entry )
        {
            if ( string.IsNullOrWhiteSpace( entry ) )
            {
                return;
            }

            Bohr currentLeaf = _root;

            foreach ( char ch in entry )
            {
                Bohr next = currentLeaf.Sons.GetValueOrDefault( ch );
                if ( next != null )
                {
                    currentLeaf = next;
                }
                else
                {
                    next = new Bohr( ch );
                    next.Parent = currentLeaf;

                    currentLeaf.Sons[ ch ] = next;
                    currentLeaf = next;
                }
            }

            currentLeaf.IsComplete = true;
        }

        public void Reset()
        {
            _current = _root;
        }

        public void SetNextState( char ch )
        {
            _current = _current.GetAutomoveWithChar( ch );
        }

        private string GetStringFromBohr( Bohr bohr )
        {
            Bohr current = bohr;
            var resultBuilder = new StringBuilder();
            Bohr parent = current.Parent;
            while ( parent != null )
            {
                resultBuilder.Insert( 0, current.Character );
                current = parent;
                parent = current.Parent;
            }

            return resultBuilder.ToString();
        }
    }
}
