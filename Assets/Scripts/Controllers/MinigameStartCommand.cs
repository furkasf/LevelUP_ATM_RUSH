using System.Collections;
using System.Collections.Generic;
using Managers;
using DG.Tweening;
using UnityEngine;

public class MinigameStartCommand : MonoBehaviour
{
    public IEnumerator StartMiniGame(int score, float delay = 0.6f)
    {

        for (int i = 0; i < score; i++)
        {
            GameObject obj = MoneyPoolManager.instance.GetMoneyFromPool();
            obj.SetActive(true);
            obj.transform.position = transform.position;
            // DOVirtual.DelayedCall(5, () => transform.DOMoveY(1, 0.5f).SetRelative(obj.transform));
            transform.DOMoveY(1, 0.5f).SetRelative(obj.transform);
            yield return new WaitForSeconds(delay);
            Debug.Log("index : " + i);
        }
    }
}
