using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.FieldGenerator;
using DefaultNamespace.GamePlay.Ore;
using Extensions;
using StaticData;
using UnityEngine;

namespace DefaultNamespace.Field
{
    public class MiningField : MonoBehaviour, IProgressReader, IProgressSaver
    {
        [SerializeField] private FieldCell[] _cells;
        [SerializeField] private FieldRaycast _fieldRaycast;
        private IGameFactory _gameFactory;
        private IFieldGenerator _fieldGenerator;

        public void OnLoaded(ref PlayerProgress progress)
        {
            RestoreField(progress.FieldData);
        }

        public void Save(ref PlayerProgress progress)
        {
            var data = new FieldData();
            var cells = new List<CellData>();
            foreach (var cell in _cells) cells.Add(cell.GetCellData());
            data.Cells = cells.ToArray();
            progress.FieldData = data;
        }

        public Vector3 GetMouseOnFieldPos()
        {
            return _fieldRaycast.GetMousePosition();
        }

        public void Construct(IGameFactory gameFactory, IWorkerMerger workerMerger,IFieldGenerator fieldGenerator)
        {
            _fieldGenerator = fieldGenerator;
            _gameFactory = gameFactory;
            foreach (var fieldCell in _cells) fieldCell.Construct(workerMerger);
        }

        private void RestoreField(FieldData data)
        {
            if (data == null || _cells?.Length != data?.Cells?.Length)
            {
                data = _fieldGenerator.FillField(_cells.ToList().Select(x => x.Weight).ToArray());
            }
            for (var i = 0; i < _cells.Length; i++) RestoreCell(_cells[i], data.Cells[i]);
        }

        private void RestoreCell(FieldCell cell, CellData data)
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

        public void Clear()
        {
            foreach (var fieldCell in _cells) fieldCell.Clear();
        }

        public FieldCell GetRandomCell()
        {
            foreach (var fieldCell in _cells)
                if (!fieldCell.HasOre() && !fieldCell.HasWorker())
                    return fieldCell;
            throw new Exception("out of field");
        }
        
        public FieldCell FindNearestFree(Vector3 pos , bool includeWorker = false)
        {
            var founded = _cells[0];
            foreach (var fieldCell in _cells)
                if (Vector3.Distance(fieldCell.transform.position, pos) <=
                    Vector3.Distance(founded.transform.position, pos) && !fieldCell.HasOre())
                {
                    if (!fieldCell.HasWorker() || includeWorker)
                    {
                        founded = fieldCell;
                    } 
                } 
            return founded;
        }
    }
}