using System;

namespace Data.ValueObject
{
    public enum CollectableTypes 
    {
        Default,
        Money = 1,
        Gold = 2,
        Diamond = 3
    }
    [Serializable]
    public class CollectableStateData 
    {
        public CollectableTypes collectableTypes = CollectableTypes.Default;
        //public CollectableTypes collectableType { get { return collectableTypes; } }
    }

}