namespace RandomManagement
{
    public interface IRandomService
    {
        public bool Probability(int percent);
        public int Range(int min, int max);
    }

    class RandomServiceService : IRandomService
    {
        public bool Probability(int percent)
        {
            return UnityEngine.Random.Range(0, 100) < percent;
        }

        public int Range(int min, int max)
        {
            return UnityEngine.Random.Range(min, max);
        }
    }
}