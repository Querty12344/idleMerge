using DefaultNamespace.Field;
using UnityEngine;

namespace DefaultNamespace.GamePlay.Ore
{
    public class WorkerMerger : IWorkerMerger
    {
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticData;

        public WorkerMerger(IStaticDataService staticData, IGameFactory gameFactory)
        {
            _staticData = staticData;
            _gameFactory = gameFactory;
        }


        public bool TryMergeWorkers(WorkerFacade worker1, WorkerFacade worker2, FieldCell at)
        {
            if (worker1.Level == worker2.Level && _staticData.GetGameData().MaxWorkerLevel > worker2.Level)
            {
                worker1.Remove();
                Debug.Log("REmove 1");
                worker2.Remove();
                Debug.Log("REmove 2");
                _gameFactory.CreateWorker(worker1.Type, worker1.Level + 1, at);
                return true;
            }

            return false;
        }
    }
}