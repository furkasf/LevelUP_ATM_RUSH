using System;
using System.Collections;
using DG.Tweening;
using Managers;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class MinigameStartCommand : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
    
        [SerializeField] private GameObject fakePlayer;

        #endregion
    

        #endregion
        

        private void Start()
        {   
            fakePlayer.SetActive(false);

        }

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();

        }

        private void SubscribeEvents()
        {
            MiniGameSignals.Instance.onStartMiniGame += OnChangeActor;
        }
        private void UnsubscribeEvents()
        {
            MiniGameSignals.Instance.onStartMiniGame -= OnChangeActor;
        }
    
        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion

        private IEnumerator StartMiniGame(int score)
        {
            
            fakePlayer.SetActive(true);
            
            fakePlayer.GetComponent<BoxCollider>().enabled = true;
            
            for (int i = 0; i < score; i++)
            {
                GameObject obj = MoneyPoolManager.Instance.GetMoneyFromPool();
                
                obj.SetActive(true);
                
                obj.transform.position = fakePlayer.transform.position;
                
                obj.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
                
                obj.transform.SetParent(null);
                
                fakePlayer.transform.DOMoveY(.75f, 0.1f).SetRelative(obj.transform)
                    .OnComplete(() => CoreGameSignals.Instance.onLevelSuccessful());
                
                yield return new WaitForSeconds(0.09f);
            }
        }
        
        private void OnChangeActor(int score)
        {
            StartCoroutine(StartMiniGame(score));
        }
    }
}
