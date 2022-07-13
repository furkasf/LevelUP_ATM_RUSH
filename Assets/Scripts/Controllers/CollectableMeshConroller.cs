using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMeshConroller : MonoBehaviour
{

    #region Self Variables
    #region Serialized Variables
    [SerializeField] private CollectableManager manager;
    [SerializeField] private MeshData meshData;
    [SerializeField] private MeshStateData meshStateData;


    #endregion

    #endregion
    
    public void SetMeshData(MeshData meshData)
    {

    }
    public void SetMeshType(MeshStateData.MeshTypes _meshType)
    {
        if(_meshType==MeshStateData.MeshTypes.MoneyFilter)
        {
            _meshType = MeshStateData.MeshTypes.GoldFilter;
        
        }
        else if(_meshType==MeshStateData.MeshTypes.GoldFilter)
        {
            _meshType = MeshStateData.MeshTypes.DiamondFilter;
        
        }

    }

    
   
}
