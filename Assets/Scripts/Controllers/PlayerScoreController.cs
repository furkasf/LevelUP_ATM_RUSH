using System.Collections;
using System.Collections.Generic;
using TMPro;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class PlayerScoreController : MonoBehaviour
    {
        #region Self Variables
        #region Serialize Variable

        [SerializeField] PlayerManager playerManager;
        [SerializeField] private TMP_Text playerScoreText;

        #endregion

        #region Private Variables

        private int _playerScore;
        private MinigameStartCommand _miniGame = new MinigameStartCommand();

        #endregion
        #endregion

        public void ChangePlayerScore(int _score)
        { 
            _playerScore += _score;
            if (_playerScore < 0)
            {
                _playerScore = 0;
            }
            playerScoreText.text = _playerScore.ToString();  
        }

        public void StartMiniGame()
        {
            StartCoroutine(_miniGame.StartMiniGame(_playerScore, transform.parent));
        }
    }
}