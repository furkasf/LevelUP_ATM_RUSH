using System.Collections;
using System.Collections.Generic;
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
    
        private void FixedUpdate()
        {
            
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
            for(int i = index; i < transform.childCount; i--)
            {
                Collectables[i].GetComponent<StackData>().Type = StackData.StackType.UnStack;
                
                Collectables[i].gameObject.SetActive(false);
            }
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
            if (Collectables is null)
            {
                return;
            }
 
            // Debug.Log("Lerp!");
            // Collectables[i].transform.position = Vector3.Lerp(new Vector3 (Collectables[i].transform.position.x, 0, 0),
            //     new Vector3(Collectables[i-1].transform.position.x * 2, 0,0),
            //     LERP_SPEED * Time.deltaTime);
            for (int i = this.transform.childCount-1; i >= 1; i--)
            {
                this.transform.GetChild(i).transform
                    .DOMoveX(this.transform.GetChild(i - 1).transform.position.x, .1f);
            }
            // for (int i = 1; i <= Collectables.Count; i++)
            // {
            //    Collectables[i].transform.DOMoveX(Collectables[i - 1].transform.position.x, 0.1f);
            // }

            // for (int i = Collectables.Count-1; i >=1; i--)
            // {
            //     Collectables[i].transform.position = Vector3.Lerp(Collectables[i].transform.position,Collectables[i-1].transform.position,
            //         Time.deltaTime * LERP_SPEED);
            //     
            // }
            
        }

        private void StartMiniGame(int GameScore)
        {
            
        }

        private void CalculateScoreWithType()
        {

        }
    
    }
}