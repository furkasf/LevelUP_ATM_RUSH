using System.Collections;
using System.Collections.Generic;
using Data.UnityObject;
using Data.ValueObject;
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
        
        #endregion

        #region Serialized Variables

        [SerializeField] private StackScoreData scoreData;
        
        [SerializeField] private StackScaleData scaleData;

        #endregion

        #region Private Variables

        private Tween _scaleTween;

        public GameObject _tempHolder;

        #endregion

        #endregion

        private void Awake()
        {
            Data = GetStackData();
            
            if(Instance == null) Instance = this; //Use MonoSingleton

            _tempHolder = GameObject.FindGameObjectWithTag("PoolHolder").transform.GetChild(0).gameObject;

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
            
            CollectableSignals.Instance.onCollissionWithStack += OnAddOnStack;

            CollectableSignals.Instance.onMovementWithLerp += OnLerpTheStack;

            CollectableSignals.Instance.onCollisionWithAtm += OnCollisionWithATM;

            CollectableSignals.Instance.onCollisionWithBand += OnCollisionWithBand;
        }

        private void UnsubscribeEvents()
        {
            CollectableSignals.Instance.onCollisionWithCollectable -= OnAddOnStack;
            
            CollectableSignals.Instance.onCollisionWithObstacle -= OnRemoveFromStack;

            CollectableSignals.Instance.onCollissionWithStack -= OnAddOnStack;
            
            CollectableSignals.Instance.onMovementWithLerp -= OnLerpTheStack;

            CollectableSignals.Instance.onCollisionWithAtm -= OnCollisionWithATM;

            CollectableSignals.Instance.onCollisionWithBand -= OnCollisionWithBand;
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

            _scaleTween = _transform.DOPunchScale(Vector3.one * scaleData.ScaleMultiplier, scaleData.ScaleDuration, 1);
        }

        IEnumerator HandleShakeOfStack()
        {
            for (int i = 0; i < Collectables.Count; i++)
            { 
                ShakeScaleOfStack(Collectables[i].transform);

                yield return new WaitForSeconds(0.4f);
            }
        }


        public void OnRemoveFromStack(int index) 
        {
            
            if(index == 0)
            {
                transform.GetChild(0).SetParent(null);
                
                Collectables[0].transform.SetParent(_tempHolder.transform);
                
                Collectables[0].SetActive(false);

                MoneyPoolManager.instance.AddMoneyToPool(Collectables[0]);

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

                int randomValue = Random.Range(-3, 3);
                
                if (randomValue + gameObject.transform.parent.position.x <= -2.6)
                {
                    randomValue = 0;
                }

                if (randomValue + gameObject.transform.parent.position.x >= 2.6)
                {
                    randomValue = 0;
                }
                Collectables[i].transform.SetParent(_tempHolder.transform);
                
                Collectables[i].transform.GetChild(1).gameObject.tag ="Collectable";

                //MoneyPoolManager.instance.AddMoneyToPool(Collectables[0]);

               
                int value = (int)Collectables[i].GetComponent<CollectableManager>().StateData;
                ScoreSignals.Instance.onChangePlayerScore(-value);

                Collectables[i].transform.DOJump(Collectables[i].transform.position + new Vector3(randomValue,0,(Random.Range(6,12))),4.0f,2,1f);

                Collectables.Remove(Collectables[i]);

            }

            Collectables.TrimExcess();
            
        }

        public void OnCollisionWithATM(int index, int value)
        {
            if (index == 0)
            {
               
                Collectables[0].transform.SetParent(_tempHolder.transform);

                MoneyPoolManager.instance.AddMoneyToPool(Collectables[0]);

                ScoreSignals.Instance.onChangeAtmScore?.Invoke(value);

                Collectables.Remove(Collectables[0]);

                Collectables.TrimExcess();

                return;
            }

        }

        public void OnCollisionWithBand(int index, int value)
        {
            if (index == 0)
            {
                GameObject temp = transform.GetChild(0).gameObject;
                
                temp.gameObject.transform.SetParent(_tempHolder.transform);
                
                Collectables.Remove(Collectables[0]);
                
                temp.transform.DOMoveX(-4, 0.5f).OnComplete(() =>
                {
                    temp.SetActive(false);
                    
                    ScoreSignals.Instance.onChangeAtmScore?.Invoke(value);
                    
                }) ;

                transform.GetChild(0).SetParent(_tempHolder.transform);

                Collectables[0].transform.DOMoveX(-6, 0.6f).OnComplete(() =>
                {
                    //nice good trick
                    ScoreSignals.Instance.onChangeAtmScore?.Invoke(value);
                    MoneyPoolManager.instance.AddMoneyToPool(Collectables[0]);
                }).OnComplete(() => Collectables.Remove(Collectables[0]));


                return;
            }

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
        
    }
}