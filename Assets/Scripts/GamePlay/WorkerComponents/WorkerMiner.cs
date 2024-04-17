using System;
using DefaultNamespace.Constants;
using UnityEngine;

namespace DefaultNamespace.GamePlay.Ore.WorkerComponents
{
    public class WorkerMiner : MonoBehaviour
    {
        public bool CanMine
        {
            get => _workerFacade.Grounded;
        }
        [SerializeField] private Ore _ore;
        private float _strength;
        private WorkerFacade _workerFacade;
        public float GetStrenght() => _strength;


        public void Construct(float strength)
        {
            _workerFacade = GetComponent<WorkerFacade>();
            _strength = strength;
        }

        public void TryStartMining()
        {
            if (_ore != null)
            {
                _ore.RemoveMiner(this);
                _ore.Break -= StopMining;
            }
            _ore?.RemoveMiner(this);
            var colliders = Physics.OverlapSphere(transform.position, GameConstants.OreRadius);
            foreach (var collider in colliders)
            {
                if (collider.gameObject.TryGetComponent<Ore>(out var ore))
                {
                    if(ore.Brouken == true)
                        continue;
                    _ore = ore;
                    _ore.AddMiner(this);
                    _ore.Break += StopMining;
                    return;
                }
            }  
            _ore = null;

        }

        public void StopMining()
        {
            if (_ore != null)
            {
                _ore.RemoveMiner(this);
                _ore.Break -= StopMining;
            }
            
            _ore = null;
            if (_workerFacade.Grounded)
            {                 
                Debug.Log("RestartMining");
                TryStartMining();
            }
        }

        private void OnDestroy()
        {
            if (_ore != null)
            {
                _ore.RemoveMiner(this);
                _ore.Break -= StopMining;
            }
        }
    }
}