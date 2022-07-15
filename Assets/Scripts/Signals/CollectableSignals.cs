using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Data.ValueObject;

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


    public event Action<CollectableStateData> onCollisionWithAtm;

    public event Action<CollectableStateData> onCollisionWithObstical;

    public event Action<CollectableStateData> onCollisionWithCollectable;
}
