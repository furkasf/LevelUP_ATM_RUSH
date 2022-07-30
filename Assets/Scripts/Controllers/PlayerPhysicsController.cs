using Enums;
using Managers;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables


        [SerializeField] private PlayerManager manager;
        [SerializeField] private new Collider collider;
        [SerializeField] private new Rigidbody rigidbody;

        #endregion
        #endregion

        private void OnTriggerEnter(Collider other)
        {
         

            if (other.CompareTag("MoneyTransform"))
            {
                UISignals.Instance.onOpenPanel?.Invoke(UIPanels.MiniGamePanel);
                manager.StopPlayerMove();
                manager.OnStartMiniGame();
            }

            if (other.CompareTag("WinZone"))
            {
                CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
            }
            if(other.CompareTag("ATM"))
            { 
                
            }
            if (other.CompareTag("Obstacle"))
            {
                manager.PushAndShakeThePlayer();
            }
        }
    
    }
}
