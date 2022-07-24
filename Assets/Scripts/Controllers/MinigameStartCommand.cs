using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class MinigameStartCommand : MonoBehaviour
{
    public void StartMiniGame(int score, float delay)
    {
        for (int i = 0; i < score; i++)
        {
            GameObject obj = MoneyPoolManager.instance.GetMoneyFromPool();
            obj.transform.position = transform.position;
            transform.position += Vector3.up;
        }
    }
}
