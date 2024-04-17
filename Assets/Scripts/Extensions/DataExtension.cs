using AssetManagement;
using DefaultNamespace.GamePlay.Ore;
using UnityEngine;

namespace Extensions
{
    public static class DataExtension
    {
        public static T ToDeserialize<T>(this string json)
        {
            return JsonUtility.FromJson<T>(json);
        }

        public static string ToJson(this object o)
        {
            return JsonUtility.ToJson(o);
        }

        public static string WorkerToString(this WorkerFacade workerFacade)
        {
            var data = workerFacade.Level + " " + (int)workerFacade.Type;
            return data;
        }

        public static void WorkerFromString(this string workerData, out int level, out WorkerTypes type)
        {
            level = int.Parse(workerData.Split(" ")[0]);
            type = (WorkerTypes)int.Parse(workerData.Split(" ")[1]);
        }
    }
}