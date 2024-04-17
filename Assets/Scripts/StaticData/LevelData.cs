using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "LevelData", fileName = "LevelData")]
    public class LevelData : ScriptableObject
    {
        public string Name;
    }
}