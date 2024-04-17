using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Constants;
using DefaultNamespace.GamePlay.Ore.WorkerComponents;
using StaticData;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace.GamePlay.Ore
{
    public class Ore : MonoBehaviour
    {
        private int _level;
        private GameObject _breakFX;
        private int _coinReward;
        private GemData _gemData;
        private float _hp;
        private float _defaultHP;
        private List<WorkerMiner> _miners = new List<WorkerMiner>();
        public event Action<int, GemData> GetReward;
        public event Action Break;
        public bool Brouken = false;
        public string ID { get; private set; }

        public float GetHpInPercent() => _hp / _defaultHP;
        public float GetCurrentHP() => _hp;
        public int GetLevel() => _level;
        

        private IEnumerator UpdateMiners()
        {
            while (true)
            {
                if (_miners.Count == 0) yield return null; 
                foreach (var miner in _miners)
                {
                    if (miner == null|| !miner.CanMine) continue;
                    _hp -= miner.GetStrenght();  
                    if (_hp <= 0)
                    {
                        OnBreak();
                        yield break;
                    } 
                }

                yield return new WaitForSeconds(GameConstants.MinersUpdateInterval);
            }
            
        }

        public void Construct(int level , string id, GameObject breakFX, float hp, int coinReward = 0,
            GemData gemData = null)
        {
            _defaultHP = hp;
            _level = level;
            ID = id;
            _breakFX = breakFX;
            _hp = hp;
            _coinReward = coinReward;
            _gemData = gemData;
            StartCoroutine(UpdateMiners());
        }


        private void OnBreak()
        {
            //Instantiate(_breakFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Brouken = true;
            GetReward?.Invoke(_coinReward, _gemData);
            Break?.Invoke();
        }

        public void AddMiner(WorkerMiner miner)
        {
            _miners.Add(miner);
        }

        public void RemoveMiner(WorkerMiner miner)
        {
            _miners.Remove(miner);
        }

        public bool HasMiners() => _miners.Count > 0;
        
        public float CalculateTimeToBreak()
        {
            float sumStrength = 0;
            _miners.ForEach(x => sumStrength += x.GetStrenght());
            return  _hp * GameConstants.MinersUpdateInterval / sumStrength;                
        }
    }
}