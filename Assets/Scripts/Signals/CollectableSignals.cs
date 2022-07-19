using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Data.ValueObject;
using UnityEngine.Events;

public class CollectableSignals : MonoBehaviour
{
    public static CollectableSignals Instance;


    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
        }
    }


    public UnityAction<int> onCollisionWithAtm = delegate(int arg0) {  };

    public UnityAction<int> onCollisionWithObstical = delegate(int arg0) {  };

    public UnityAction<GameObject>onCollisionWithCollectable = delegate{ };
    
    public UnityAction<GameObject> onCollissionWithStack = delegate(GameObject arg0) {  };
}
