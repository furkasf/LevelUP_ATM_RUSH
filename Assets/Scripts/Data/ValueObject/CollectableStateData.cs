using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CollectableStateData 
{
    public enum CollectableTypes 
    {
        Default,
        Money,
        Gold,
        Diamond
    }
     public CollectableTypes collectableTypes=CollectableTypes.Default;
    //public CollectableTypes collectableType { get { return collectableTypes; } }
}
