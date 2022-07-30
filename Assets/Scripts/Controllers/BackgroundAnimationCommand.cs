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
        
        private void OnTriggerExit(Collider other)
        {
            PlayBackAnim();
        }

        public void PlayForwardAnim()
        {
            transform.DOLocalMoveZ(4.0f, .2f);
        }

        public void PlayBackAnim()
        {
            transform.DOLocalMoveZ(0f, 1.2f);
        }
        public void PlayUpwardAnim()
        {
            
        }
    }
}
