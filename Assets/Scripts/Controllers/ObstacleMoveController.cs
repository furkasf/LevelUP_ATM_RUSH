using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMoveController : MonoBehaviour
{
    Transform ObstacleTr;

    private void Awake()
    {
        ObstacleTr = GetComponent<Transform>();
    }
    void Start()
    {
        ObstacleMoveX();
    }
    private void Update()
    {
       
    }

    public void ObstacleMoveX()
    {
        ObstacleTr.transform.DOMoveX(6, 2.5f).SetLoops(60,LoopType.Yoyo);
        
    }
}
