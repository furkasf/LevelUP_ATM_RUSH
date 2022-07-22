using System;
using UnityEngine;
using UnityEngine.Events;

public class ScoreSignals : MonoBehaviour
{
    public static ScoreSignals Instance;
   

    private void Awake()
    {
        if(Instance == null ) Instance = this;
    }

    public  UnityAction<int> onChangeAtmScore = delegate { };
    public UnityAction<int> onChangePlayerScore = delegate { };
}
