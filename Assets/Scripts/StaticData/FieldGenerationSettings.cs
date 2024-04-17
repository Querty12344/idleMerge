using System;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    [CreateAssetMenu (menuName = "GenerationData" , fileName = "GenerationData")]
    public class FieldGenerationSettings:ScriptableObject
    {
        public int GemsOnFieldCount;
        public int OreLevelDistortion;
        public int ByLevelArifmModiefer;
        public int ByLevelGeometricmModiefer;
        public int GemProbability;
        public int OreBoundProbability;
        public int OreBound;
    }
}