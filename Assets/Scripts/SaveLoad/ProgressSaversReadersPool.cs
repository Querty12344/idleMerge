using System.Collections.Generic;

namespace DefaultNamespace
{
    public class ProgressSaversReadersPool
    {
        public readonly List<IProgressReader> ProgressReaders = new();
        public readonly List<IProgressSaver> ProgressSavers = new();

        public void AddProgressReader(IProgressReader progressReader)
        {
            ProgressReaders.Add(progressReader);
        }

        public void AddProgressSaver(IProgressSaver progressSaver)
        {
            ProgressSavers.Add(progressSaver);
        }

        public void RemoveSaver(IProgressSaver progressSaver)
        {
            ProgressSavers.Remove(progressSaver);
        }

        public void RemoveReader(IProgressReader progressReader)
        {
            ProgressReaders.Remove(progressReader);
        }
    }
}