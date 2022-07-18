using System;
using System.Collections;
using System.Collections.Generic;
using Data.ValueObject;
using UnityEngine;

public class CollectableMeshConroller : MonoBehaviour
{   
    

    #region Self Variables
    #region Serialized Variables
    [SerializeField] private CollectableManager manager;
    [SerializeField] private MeshData meshData;
    [SerializeField] private MeshStateData meshStateData;
    
    public List<MeshFilter> meshFilter = new List<MeshFilter>();

    #endregion

    #endregion

    private void Start()
    {
        gameObject.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh = meshFilter[0].sharedMesh;
    }

    public void SetMeshData(MeshData meshData)
    {
    
    }
    public void SetMeshType(int id)
    {
        gameObject.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh = meshFilter[id].sharedMesh;
    }

    
   
}
