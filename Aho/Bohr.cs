using System.Collections.Generic;

namespace Aho
{
    class Bohr
    {
        public char Character { get; set; }
        public bool IsComplete { get; set; }
        public Bohr GoodSuffLink { get; set; }
        public Bohr SuffLink { get; set; }
        public Bohr Parent { get; set; }

        public Dictionary<char, Bohr> Sons { get; set; }
        public Dictionary<char, Bohr> NextStateByChar { get; set; }

        public Bohr( char character )
        {
            Character = character;
            Sons = new Dictionary<char, Bohr>();
            NextStateByChar = new Dictionary<char, Bohr>();
        }

        public Bohr GetSuffLink()
        {
            if ( SuffLink != null )
            {
                return SuffLink;
            }

            if ( Parent == null )
            {
                // Корень
                SuffLink = this;
            } 
            else if ( Parent.Parent == null )
            {
                // Сын корня
                SuffLink = Parent;
            }
            else
            {
                SuffLink = Parent.GetSuffLink().GetAutomoveWithChar( Character );
            }

            return SuffLink;
        }

        public Bohr GetGoodSuffLink()
        {
            if ( GoodSuffLink != null )
            {
                return GoodSuffLink;
            }

            Bohr suffLink = GetSuffLink();

            if ( suffLink.Parent == null )
            {
                GoodSuffLink = suffLink;
            }
            else
            {
                GoodSuffLink = suffLink.IsComplete ? suffLink : suffLink.GetGoodSuffLink();
            }

            return GoodSuffLink;
        }

        public Bohr GetAutomoveWithChar( char character )
        {
            Bohr next = NextStateByChar.GetValueOrDefault( character );
            if ( next != null )
            {
                return next;
            }

            Bohr forward = Sons.GetValueOrDefault( character );
            if ( forward == null )
            {
                forward = Parent == null ? this : GetSuffLink().GetAutomoveWithChar( character );
            }

            NextStateByChar[ character ] = forward;
            return forward;
        }
    }
}
