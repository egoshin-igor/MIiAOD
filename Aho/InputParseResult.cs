using System.Collections.Generic;
using System.Linq;

namespace Aho
{
    public class InputParseResult
    {
        public List<string> Entries { get; private set; }
        public List<string> Lines { get; private set; }

        public InputParseResult( IEnumerable<string> entries, IEnumerable<string> lines )
        {
            Entries = entries.ToList();
            Lines = lines.ToList();
        }
    }
}
