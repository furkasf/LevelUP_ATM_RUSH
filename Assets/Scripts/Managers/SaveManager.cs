using System.Collections;
using Enums;
using Signals;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class SaveManager : MonoBehaviour
    {

        #region Self Variables

        #region Private Variables
        #endregion

        #endregion

        private void Awake()
        {
            if(!ES3.FileExists())
            {
                ES3.Save("Score", 0);
                ES3.Save("Level", 0);
            }
        }

        #region Subscription

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        private void Subscribe()
        {
            CoreGameSignals.Instance.onSaveGameData += OnSaveGameData;
            CoreGameSignals.Instance.onLoadGameData += OnLoadGameData;
        }

        private void UnSubscribe()
        {
            CoreGameSignals.Instance.onSaveGameData -= OnSaveGameData;
            CoreGameSignals.Instance.onLoadGameData -= OnLoadGameData;
        }
        #endregion]

        private void OnSaveGameData(SaveStates state, int data)
        {
            if(state == SaveStates.Score)
            {
                int totalScore = ES3.Load<int>("Score") + data; 
                ES3.Save("Score", totalScore);
            }
            if(state == SaveStates.Level)
            {
                ES3.Save("Level", data);
            }
        }

        private int OnLoadGameData(SaveStates state)
        {
            if (state != SaveStates.Score) return ES3.Load<int>("Score");
            else if (state == SaveStates.Level) return ES3.Load<int>("Level");
            else return 0;
        }
    }

   
}