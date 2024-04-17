using System;
using AssetManagement;
using DefaultNamespace.GamePlay.Ore.WorkerComponents;
using UnityEngine;

namespace DefaultNamespace.GamePlay.Ore
{
    public class WorkerFacade : MonoBehaviour
    {
        [SerializeField] private WorkerMover Mover;
        [SerializeField] private WorkerMiner Miner;
        public WorkerTypes Type { get; private set; }
        public int Level { get; private set; }
        public event Action<WorkerFacade> Move;
        public bool Grounded
        {
            get => !Mover.IsFlying;
        }

        public void StopMining()
        {
            Miner.StopMining();
        }

        public void OnGrounded()
        {
            Miner.TryStartMining();
        }

        public void Construct(int level, WorkerTypes type)
        {
            Level = level;
            Type = type;
        }

        public void Remove()
        {
            Destroy(gameObject);
        }

        public void OnFly()
        {
            StopMining();
        }
    }
}