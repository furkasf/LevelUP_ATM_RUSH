using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Controllers
{
    public class StackManagerAnimationController : MonoBehaviour
    {
        #region Self Variables
        #region public
        public float SCALE_MULTIPLIER = .5f;
        public float SCALE_DURATION = .5f;
        #endregion
        #region Private
        private Tween scaleTween;
        #endregion
        #endregion


        public void LerpTheStack(ref List<Transform> collectable)
        {
            if(collectable != null)
            {
                for(int i = 0; i < collectable.Count && collectable.Count > 1 ; i--)
                {
                    collectable[i].transform.DOMoveX(collectable[i - 1].transform.position.x, 0.1f);
                }
            }
        }

        private void ShakeScaleOfStack( Transform transform)
        {
            if (scaleTween != null)
                scaleTween.Kill(true);

            scaleTween = transform.DOPunchScale(Vector3.one * SCALE_MULTIPLIER, SCALE_DURATION, 2);

        }
        public IEnumerator HandleStackScaleCo(List<Transform> collectable)
        {
            for (int i = 0; i < collectable.Count; i++)
            {
                ShakeScaleOfStack(collectable[i].transform);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}