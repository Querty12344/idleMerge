using Extensions;
using UnityEngine;

namespace DefaultNamespace
{
    public class SaveLoadProgress
    {
        private const string _saveKey = "save";

        public void SaveProgress(ref PlayerProgress progress)
        {
            PlayerPrefs.SetString(_saveKey, progress.ToJson());
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(_saveKey).ToDeserialize<PlayerProgress>();
        }
    }
}