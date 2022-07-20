using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

namespace Managers
{
    public class StackManager : MonoBehaviour
    {
        public static StackManager Instance;
        #region Self Variables
        #region public
        public List<GameObject> Collectables = new List<GameObject>();
        public GameObject TempHolder;
        public int AtmScore;
        public int Gamescore;
        public float LERP_SPEED = 2.5f;
        public float SCALE_MULTIPLIER = .1f;
        public float SCALE_DURATION = .2f;
        public float JUMP_RADIUS;

        private Tween scaleTween;
        #endregion
        #endregion

        private void Awake()
        {
            if(Instance == null) Instance = this;
        }

        #region Event Subscription
    
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CollectableSignals.Instance.onCollisionWithCollectable += AddOnStack;
            
            CollectableSignals.Instance.onCollisionWithObstical += RemoveFromStack;
            
            CollectableSignals.Instance.onCollisionWithAtm += RemoveFromStack;

            CollectableSignals.Instance.onCollissionWithStack += AddOnStack;
        }

        private void UnsubscribeEvents()
        {
            CollectableSignals.Instance.onCollisionWithCollectable -= AddOnStack;
            
            CollectableSignals.Instance.onCollisionWithObstical -= RemoveFromStack;
            
            CollectableSignals.Instance.onCollisionWithAtm -= RemoveFromStack;

            CollectableSignals.Instance.onCollissionWithStack -= AddOnStack;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        private void Update()
        {
            LerpTheStack();
        }
   

        private void ShakeScaleOfStack(Transform transform)
        {
             if (scaleTween != null)
                 scaleTween.Kill(true);
             
             scaleTween = transform.DOPunchScale(Vector3.one * SCALE_MULTIPLIER, SCALE_DURATION, 1);
             
        }

        IEnumerator HandleShakeOfStack()
        {
            for (int i = 0; i < Collectables.Count; i++)
            { 
                ShakeScaleOfStack(Collectables[i].transform);
                
                yield return new WaitForSeconds(0.3f);
            }
     
        }


        public void RemoveFromStack(int index) 
        {
            Debug.Log(index);
           
            
            if(index == 0)
            {
                transform.GetChild(0).SetParent(null);
                for(int i = 0; i < Collectables.Count; i++)
                {
                    if(Collectables[i].transform.parent == null)
                    {
                        Collectables[i].transform.parent = TempHolder.transform;
                        Collectables[i].SetActive(false);
                        Collectables.Remove(Collectables[i]);
                    }
                }
                Collectables.TrimExcess();
                return;
            }

            for (int i = index; i < Collectables.Count; i--)
            {
                Collectables[i].transform.SetParent(null);
                Collectables.Remove(Collectables[i]);
               
            }
            Collectables.TrimExcess();
        }

        private void AddOnStack(GameObject go)
        {   
 
            foreach(GameObject i in Collectables)
            {
                i.transform.Translate(Vector3.forward);
            }
            
            go.transform.parent = transform;
            
            go.transform.localPosition = Vector3.forward;
            
            Collectables.Add(go);
            
            StartCoroutine(HandleShakeOfStack());

        }

        private void LerpTheStack()
        {
            if ( Collectables.Count < 1)
            {
                return;
            } 
            for (int i = Collectables.Count - 1; i >= 1; i--)
            {
                Collectables[i - 1].transform.DOMoveX(Collectables[i].transform.position.x, .1f);
            }
            
        }

        private void StartMiniGame(int GameScore)
        {
            
        }
    }
}