using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class MoneyPoolManager : MonoBehaviour
    {
        #region Self Variable
        #region Public Variables

        public static MoneyPoolManager Instance;

        #endregion

        #region Serialize Variable

        [SerializeField] GameObject unUsedMoney;//prefab
        [SerializeField] GameObject moneyContainer;
        [SerializeField] List<GameObject> moneyPool = new List<GameObject>();
        [SerializeField] int ballSize;

        #endregion
        #endregion

        private void Awake()
        {
            if (Instance == null) Instance = this;
        }

        private void Start()
        {
            moneyPool = Setup(ballSize);
        }

        public List<GameObject> Setup(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject ball = Instantiate(unUsedMoney);
                ball.transform.parent = moneyContainer.transform;
                ball.SetActive(false);
                moneyPool.Add(ball);
            }

            return moneyPool;
        }

        public GameObject GetMoneyFromPool()
        {
            //cheack any in active ball from pool
            foreach (var ball in moneyPool)
            {
                if (ball.activeInHierarchy == false)
                {
                    ball.SetActive(true);
                    return ball;
                   
                }
            }
            //if doesnt have extra ball in pool creat new ball and pool
            GameObject newBall = Instantiate(unUsedMoney);
            newBall.transform.parent = moneyContainer.transform;
            moneyPool.Add(newBall);
            return newBall;
        }

        //add money used in level to pool
        public void AddMoneyToPool(GameObject money)
        {
            if (money.active)
            { 
                money.SetActive(false); 
            }

            moneyPool.Add(money);
        }

        public void HideAllActiveMoney()
        {
            foreach(GameObject money in moneyPool)
            {
                if(money.active)
                {
                    money.SetActive(false);
                    money.transform.parent = moneyContainer.transform;
                }
            }
        }

    }
}