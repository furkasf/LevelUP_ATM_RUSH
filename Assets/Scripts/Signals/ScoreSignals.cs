using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSignals : MonoBehaviour
{
    public static ScoreSignals Instance;
   

    private void Awake()
    {
        if(Instance == null ) Instance = this;
    }

    public event Action<int> onChangeAtmScore;
    public event Action<int> onChangePlayerScore;
}
