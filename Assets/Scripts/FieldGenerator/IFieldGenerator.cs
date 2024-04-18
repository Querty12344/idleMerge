using StaticData;

namespace DefaultNamespace.FieldGenerator
{
    public interface IFieldGenerator
    {
        
        public FieldData FillField(int[] fieldCellsWeights);
    }
}