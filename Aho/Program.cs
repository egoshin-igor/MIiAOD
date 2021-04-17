using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aho
{
    class FoundEntry
    {
        public int Position { get; set; }
        public int Line { get; set; }
        public string Word { get; set; }
    }

    class Program
    {
        static void Main()
        {
            InputParseResult input = ParseInput( "input.txt" );
            IReadOnlyList<FoundEntry> foundEntries = FindEntries( input );
            PrintResult( foundEntries, "../../../out.txt" );
        }


        private static InputParseResult ParseInput( string inFileUri )
        {
            using ( var streamReader = new StreamReader( inFileUri ) )
            {
                int entriesCount = int.Parse( streamReader.ReadLine() );
                var entries = new List<string>();
                for ( int i = 0; i < entriesCount; i++ )
                {
                    entries.Add( streamReader.ReadLine() );
                }
                string fileUri = streamReader.ReadLine().Trim();
                return new InputParseResult( entries, File.ReadAllLines( fileUri ) );
            }
        }

        private static void PrintResult( IReadOnlyList<FoundEntry> foundEntries, string outUri )
        {
            var sorted = foundEntries
                .OrderBy( x => x.Line )
                .ThenBy( x => x.Position )
                .ToList();

            using ( var streamWriter = new StreamWriter( outUri ) )
            {
                foreach ( FoundEntry entry in sorted )
                {
                    var str = $"Line {entry.Line + 1}, position {entry.Position + 1}: {entry.Word}";
                    streamWriter.WriteLine( str );
                }

                if ( sorted.Count == 0 )
                {
                    streamWriter.WriteLine( "No enrty" );
                }
            }
        }

        private static IReadOnlyList<FoundEntry> FindEntries( InputParseResult input )
        {
            var foundEntries = new List<FoundEntry>();
            AhoAutomat ahoAutomat = GetAhoAutomatWithBuildedBohr( input.Entries );

            Dictionary<string, string> caseSensitiveEntries = input.Entries
                .ToDictionary( x => x.ToLower(), x => x );

            for ( int lineNumber = 0; lineNumber < input.Lines.Count; lineNumber++ )
            {
                string line = input.Lines[ lineNumber ];
                for ( int charPosition = 0; charPosition < line.Length; charPosition++ )
                {
                    char ch = line[ charPosition ];
                    ahoAutomat.SetNextState( char.ToLowerInvariant( ch ) );
                    IReadOnlyList<string> currentEntries = ahoAutomat.GetCurrentEntries();

                    foreach ( string currentEntry in currentEntries )
                    {
                        var entryWithEndPosition = new FoundEntry
                        {
                            Line = lineNumber,
                            Position = charPosition,
                            Word = caseSensitiveEntries[ currentEntry ]
                        };
                        foundEntries.Add( BuildEntryWithStartPosition( input.Lines, entryWithEndPosition ) );
                    }
                }
                ahoAutomat.SetNextState( ' ' );
            }

            return foundEntries;
        }

        private static AhoAutomat GetAhoAutomatWithBuildedBohr( IEnumerable<string> entries )
        {
            var result = new AhoAutomat();

            foreach ( string entry in entries )
            {
                result.AddEnrty( entry.ToLower() );
            }

            return result;
        }

        public static FoundEntry BuildEntryWithStartPosition( List<string> inputLines, FoundEntry foundEnrtyWithEndPosition )
        {
            var line = foundEnrtyWithEndPosition.Line;
            var pos = foundEnrtyWithEndPosition.Position - foundEnrtyWithEndPosition.Word.Length + 1;

            while ( pos < 0 )
            {
                line -= 1;
                pos += inputLines[ line ].Length + 1;
            }

            return new FoundEntry
            {
                Position = pos,
                Line = line,
                Word = foundEnrtyWithEndPosition.Word
            };
        }
    }
}
