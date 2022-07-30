﻿using System.Collections;
using Enums;
using Commands;
using Signals;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class SaveManager : MonoBehaviour
    {

        #region Self Variables

        #region Private Variables

        private LoadGameCommand _loadGameCommand;
        private SaveGameCommand _SaveGameCommand;

        #endregion

        #endregion

        private void Awake()
        {

            _loadGameCommand = new LoadGameCommand();
            _SaveGameCommand = new SaveGameCommand();

            //if there is no save file created
            if (!ES3.FileExists())
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
            CoreGameSignals.Instance.onSaveGameData += _SaveGameCommand.OnSaveGameData;
            CoreGameSignals.Instance.onLoadGameData += _loadGameCommand.OnLoadGameData;
        }

        private void UnSubscribe()
        {
            CoreGameSignals.Instance.onSaveGameData -= _SaveGameCommand.OnSaveGameData;
            CoreGameSignals.Instance.onLoadGameData -= _loadGameCommand.OnLoadGameData;
        }

        #endregion]

    }
}