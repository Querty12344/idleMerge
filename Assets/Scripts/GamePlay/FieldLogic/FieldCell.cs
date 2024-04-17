using DefaultNamespace.GamePlay.Ore;
using Extensions;
using StaticData;
using UnityEngine;

namespace DefaultNamespace.Field
{
    public class FieldCell : MonoBehaviour
    {
        [SerializeField] public int  Weight;
        [SerializeField] private Transform _root;
        [SerializeField] private WorkerFacade _worker;
        private Ore _ore;
        private IWorkerMerger _workerMerger;

        public void Construct(IWorkerMerger workerMerger)
        {
            _workerMerger = workerMerger;
        }

        public bool HasOre()
        {
            return _ore != null;
        }

        public bool HasWorker()
        {
            return _worker != null;
        }

        public void Fill(Ore ore)
        {
            _ore = ore;
        }

        public Transform GetRoot()
        {
            return _root;
        }


        public void Free()
        {
            _worker = null;
        }

        public void Fill(WorkerFacade worker)
        {
            _worker = worker;
            _worker.Move += OnWorkerMoved;
        }

        public bool TryMerge(WorkerFacade worker)
        {
            if (_worker == worker)
            {
                return false;
            }

            return _workerMerger.TryMergeWorkers(_worker, worker, this);
        }

        private void OnWorkerMoved(WorkerFacade worker)
        {
            _worker = null;
        }


        public CellData GetCellData()
        {
            var data = new CellData();
            if (HasOre())
            {
                data.CellType = CellType.ore;
                data.CellContentID = _ore.ID;
            }
            else if (HasWorker())
            {
                data.CellType = CellType.worker;
                data.CellContentID = _worker.WorkerToString();
                Debug.Log("check data for worker");
            }
            else
            {
                data.CellType = CellType.empty;
                data.CellContentID = "";
            }

            return data;
        }

        public void Clear()
        {
            Destroy(_worker);
            Destroy(_ore);
        }
    }
}