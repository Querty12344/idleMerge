using DefaultNamespace.Field;

namespace DefaultNamespace.GamePlay.Ore
{
    public interface IWorkerMerger
    {
        public bool TryMergeWorkers(WorkerFacade worker1, WorkerFacade worker2, FieldCell at);
    }
}