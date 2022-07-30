﻿using DG.Tweening;
using UnityEngine;

namespace Controllers
{
    public class AtmAnimationCommand : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                transform.DOMoveY(-10, 1f).SetEase(Ease.Linear);
            }
        }
    }
}