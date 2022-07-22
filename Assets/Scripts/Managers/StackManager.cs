using System.Collections;
using System.Collections.Generic;
using Data.UnityObject;
using UnityEngine;
using DG.Tweening;
using Signals;
using Random = UnityEngine.Random;

namespace Managers
{
    public class StackManager : MonoBehaviour
    {
        public static StackManager Instance;
        #region Self Variables
        #region Public Variables

        [Header("Data")] public StackData Data;
        
        [Space]
        public List<GameObject> Collectables = new List<GameObject>();
        
        public GameObject TempHolder;
        
        #endregion

        #region Serialized Variables

        [SerializeField] private StackScoreData scoreData;
        
        [SerializeField] private StackScaleData scaleData;

        #endregion

        #region Private Variables

        private Tween _scaleTween;

        #endregion
        
        #endregion

        private void Awake()
        {
            Data = GetStackData();
            
            if(Instance == null) Instance = this; //Use MonoSingleton
            
            SetStackData();
        }

        private StackData GetStackData() => Resources.Load<CD_Stack>("Data/CD_Stack").data;

        private void SetStackData()
        {
            scoreData = Data.scoreData;
            scaleData = Data.scaleData;
        }
        #region Event Subscription
    
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CollectableSignals.Instance.onCollisionWithCollectable += OnAddOnStack;
            
            CollectableSignals.Instance.onCollisionWithObstacle += OnRemoveFromStack;
            
            CollectableSignals.Instance.onCollisionWithAtm += OnRemoveFromStack;

            CollectableSignals.Instance.onCollissionWithStack += OnAddOnStack;

            CollectableSignals.Instance.onMovementWithLerp += OnLerpTheStack;
        }

        private void UnsubscribeEvents()
        {
            CollectableSignals.Instance.onCollisionWithCollectable -= OnAddOnStack;
            
            CollectableSignals.Instance.onCollisionWithObstacle -= OnRemoveFromStack;
            
            CollectableSignals.Instance.onCollisionWithAtm -= OnRemoveFromStack;

            CollectableSignals.Instance.onCollissionWithStack -= OnAddOnStack;
            
            CollectableSignals.Instance.onMovementWithLerp -= OnLerpTheStack;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        
        
        private void ShakeScaleOfStack(Transform _transform)
        {   
            if (_scaleTween != null)
                _scaleTween.Kill(true);
            
            _scaleTween = _transform.DOPunchScale(Vector3.one * scaleData.ScaleMultiplier, scaleData.ScaleDuration, 1).SetAutoKill(true);
        }

        IEnumerator HandleShakeOfStack()
        {
            for (int i = 0; i < Collectables.Count; i++)
            { 
                ShakeScaleOfStack(Collectables[i].transform);

                yield return new WaitForSeconds(0.3f);
            }
        }


        public void OnRemoveFromStack(int index) 
        {
            
            if(index == 0)
            {
                transform.GetChild(0).SetParent(null);
                
                Collectables[0].transform.SetParent(TempHolder.transform);
                
                Collectables[0].SetActive(false);
                
                Collectables.Remove(Collectables[0]);

                Collectables.TrimExcess();
                
                return;
            }
    
            for (int i = index; i < Collectables.Count; i--)
            {
                if (i < 0)  // when index lower than 0 it cause trouble(null excep.)
                {
                    return;
                }
                
                Collectables[i].transform.SetParent(TempHolder.transform);
                
                Collectables[i].transform.GetChild(1).gameObject.tag ="Collectable";
                
                Collectables[i].transform.DOJump(Collectables[i].transform.position + new Vector3(Random.Range(-3,3),0,(Random.Range(9,15))),4.0f,2,1f);

                Collectables.Remove(Collectables[i]);

            }

            Collectables.TrimExcess();
            
        }

        private void OnAddOnStack(GameObject gO)
        {   
 
            foreach(GameObject i in Collectables)
            {
                i.transform.Translate(Vector3.forward);
            }
            
            gO.transform.parent = transform;
            
            gO.transform.localPosition = Vector3.forward;
            
            Collectables.Add(gO);
            
            StartCoroutine(HandleShakeOfStack());

        }

        private void OnLerpTheStack()
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
        
        // tamamen bağımsız yapalım.
        private void StartMiniGame(int GameScore)
        {
            
        }
    }
}