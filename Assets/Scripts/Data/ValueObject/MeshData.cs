using System;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class MeshData 
    {
        public MeshFilter CollectableFilter;
        public GameObject CollectableObject;
        public Texture   collectableTexture;
    }
}
