namespace Deikstra
{
    public class MinDistanceResult
    {
        public long MinDistance { get; }
        public string Path { get; }
        public MinDistanceResult( long minDistance, string path )
        {
            MinDistance = minDistance;
            Path = path;
        }

        public static MinDistanceResult NotFound()
        {
            return new MinDistanceResult( -1, "Путь не найден" );
        }
    }
}
