namespace RandomManagement
{
    public interface IRandomService
    {
        public bool Probability(int percent);
        public int Range(int min, int max);
        int[] GetRandomArray(int min, int max, int length);
    }
}