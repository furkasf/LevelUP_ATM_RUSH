using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MeshStateData 
{
    public enum MeshTypes
    {
        MoneyFilter,
        GoldFilter,
        DiamondFilter
    }
    public MeshTypes meshType=MeshTypes.MoneyFilter;
   // public MeshStateData MeshState { get { return meshState; } }
}
