using TMPro;
using UnityEngine;

namespace Controllers
{
    public class AtmCommand : MonoBehaviour
    {
        #region Self Variables
        #region Serialize
        [SerializeField] TMP_Text m_Text;
        #endregion
        #endregion

        #region Subscriptions

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
            ScoreSignals.Instance.onChangeAtmScore += OnChangeAtmScore;
        }
        private void UnSubscribe()
        {
            ScoreSignals.Instance.onChangeAtmScore -= OnChangeAtmScore;
        }
        #endregion

        private void OnChangeAtmScore(int AtmScore)
        {

        }
    }
}