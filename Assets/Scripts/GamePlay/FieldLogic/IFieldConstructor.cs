using StaticData;

namespace DefaultNamespace.Field
{
    public interface IFieldConstructor
    {
        void RestoreField(MiningField field);
        void RestoreCell(FieldCell cell, CellData data);
    }
}