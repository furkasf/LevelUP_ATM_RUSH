using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CD_Collectables", menuName = "AtmRush/CD_Collectables", order = 0)]
public class CD_Collectables : ScriptableObject
{
   public List<MeshData> filters;
    public MeshStateData meshState;
    public CollectableStateData collectableStateData;

}
