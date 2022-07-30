using System;
using UnityEngine;
using DG.Tweening;
using Signals;


namespace Controllers
{
    public class BackgroundAnimationCommand : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("FakePlayer"))
            {
                PlayForwardAnim();
                MiniGameSignals.Instance.onCollisionWithBlock?.Invoke(gameObject);
            }
        }

        public void PlayForwardAnim()
        {
            transform.DOLocalMoveZ(4.0f, .2f);
        }

        public void PlayBackAnim()
        {
            transform.DOLocalMoveZ(-4.0f, .2f);
        }
        public void PlayUpwardAnim()
        {
            
        }
    }
}
