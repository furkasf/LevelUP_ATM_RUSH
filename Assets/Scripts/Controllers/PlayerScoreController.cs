using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class PlayerScoreController : MonoBehaviour
    {
        #region Self Variables
        #region Serialize

        [SerializeField] private TMP_Text PlayerScoreText;
        #endregion
        #endregion

        public void ChangePlayerScore(int _score)
        {
            PlayerScoreText.text += _score.ToString();
        }
    }
}