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
        
    }

    public void Mini(int score, float delay)
    {
        
        for(int i = 0; i < score; i++)
        {
            GameObject obj = MoneyPoolManager.instance.GetMoneyFromPool();
            obj.transform.position = transform.position;
            transform.position += Vector3.up;
           
        }
        
    }
}
