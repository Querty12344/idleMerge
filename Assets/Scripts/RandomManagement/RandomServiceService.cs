using System.Linq;
using DefaultNamespace.Constants;

namespace RandomManagement
{
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

        public int[] GetRandomArray(int min, int max, int length)
        {
            int[] array = new int[length];
            if (max < length)
            {
                for (int i = 0; i < length; i++)
                {
                    array[i] = UnityEngine.Random.Range(min, max);
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    bool found = false;
                    for (int j = 0; j < GameConstants.MaxRandomIterations; j++)
                    {
                        int next = UnityEngine.Random.Range(min, max);
                        if (!array.Contains(next))
                        {
                            array[i] = next;
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        array[i] = UnityEngine.Random.Range(min, max);
                    } 
                }
               
            }
            return array;
        }
    }
}