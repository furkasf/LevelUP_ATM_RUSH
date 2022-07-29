using System;
using UnityEngine;

namespace Controllers
{
    public class cinemationanim : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.Play("CM vcam1");
            }

        }

    }
}