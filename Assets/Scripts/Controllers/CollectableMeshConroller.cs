using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class CollectableMeshConroller : MonoBehaviour
    {
        #region Self Variables
        #region Serialized Variables

        public List<MeshFilter> meshFilter = new List<MeshFilter>();

        #endregion

        #endregion

        private void Start()
        {
            gameObject.GetComponent<MeshFilter>().sharedMesh = meshFilter[0].sharedMesh;
        }
    
        public void SetMeshType(int id)
        {
            Debug.Log(meshFilter[id].name);
            gameObject.GetComponent<MeshFilter>().sharedMesh = meshFilter[id].sharedMesh;
        }

    
   
    }
}
