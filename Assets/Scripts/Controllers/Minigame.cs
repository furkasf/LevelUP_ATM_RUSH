using System.Collections;
using System.Collections.Generic;
using Managers;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class Minigame : MonoBehaviour
{
 
    void Start()
    {
        StartCoroutine(Mini(20));
    }

    public IEnumerator Mini(int score)
    {
        
        for(int i = 0; i < score; i++)
        {
            GameObject obj = MoneyPoolManager.instance.GetMoneyFromPool();
            
            obj.SetActive(true);
            
            obj.transform.position = transform.position;
            
            transform.DOMoveY(1, 0.1f).SetRelative(obj.transform);
            
            yield return new WaitForSeconds(0.09f);
        }
        
    }
}
