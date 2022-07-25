using System.Collections;
using System.Collections.Generic;
using Managers;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Mini(20, 4));
    }

    public IEnumerator Mini(int score, float delay = 0.2f)
    {
        
        for(int i = 0; i < score; i++)
        {
            GameObject obj = MoneyPoolManager.instance.GetMoneyFromPool();
            obj.SetActive(true);
            obj.transform.position = transform.position;
            // DOVirtual.DelayedCall(5, () => transform.DOMoveY(1, 0.5f).SetRelative(obj.transform));
            transform.DOMoveY(1, 0.1f).SetRelative(obj.transform);
            yield return new WaitForSeconds(0.09f);
            Debug.Log("index : " + i);
        }
        
    }
}
