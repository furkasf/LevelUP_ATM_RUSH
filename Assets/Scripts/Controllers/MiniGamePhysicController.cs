using Signals;
using UnityEngine;
namespace Controllers
{
    public class MiniGamePhysicController: MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Stack"))
            {
                MiniGameSignals.Instance.onCollisionWithStack?.Invoke();
            }
        }
    }
}