using System.Linq;
using DefaultNamespace.FieldGenerator;
using Extensions;
using StaticData;

namespace DefaultNamespace.Field
{
    public class FieldConstructor : IFieldConstructor
    {
        private  readonly IProgressService _progressService;
        private readonly IFieldGenerator _fieldGenerator;
        private readonly IGameFactory _gameFactory;

        public FieldConstructor(IProgressService progressService , IFieldGenerator fieldGenerator , IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            _fieldGenerator = fieldGenerator;
            _progressService = progressService;
        }
        public void RestoreField(MiningField field)
        {
            var data = _progressService.GetFieldData();
            if (data == null || field.Cells.Count != data?.Cells?.Length)
            {
                data = _fieldGenerator.FillField(field.Cells.Select(x => x.Weight).ToArray());
            }

            int i = 0;
            foreach (var fieldCell in field.Cells)
            {
                RestoreCell(fieldCell, data.Cells[i]);
                i++;
            }
        }

        public void RestoreCell(FieldCell cell, CellData data)
        {
            cell.Clear();
            switch (data.CellType)
            {
                case CellType.ore:
                    _gameFactory.CreateOre(data.CellContentID, cell);
                    break;
                case CellType.worker:
                    data.CellContentID.WorkerFromString(out var level, out var type);
                    _gameFactory.CreateWorker(type, level, cell);
                    break;
            }
        }
    }
}