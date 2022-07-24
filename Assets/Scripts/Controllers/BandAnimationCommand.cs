using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BandAnimationCommand : MonoBehaviour
    {
        #region Self Variables

        #region Serialize Variables
        [SerializeField] private float scrollSpeed = 0.5f;
        [SerializeField] private Renderer renderer;
        #endregion

        #endregion

        private void Awake()
        {
            renderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            float offset = Time.time * scrollSpeed;
            renderer.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
        }
    }
}