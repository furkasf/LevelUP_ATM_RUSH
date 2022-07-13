using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePhysicsController : MonoBehaviour
{
    #region Self Variables
    #region Serializefield Variables
    [SerializeField] private CollectableManager collectableManager;
    [SerializeField] private Collider col;
    [SerializeField] private Rigidbody rb;




    #endregion


    #endregion
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Atm"))
        {
            CollisionWithAtm();

        }
    }
    public void CollisionWithAtm()
    {
        collectableManager.OnCollisionWithAtm();
    }

    public void CollisionWithCollectable()
    {
        collectableManager.OnCollisionWithCollectable();
    }

    public void CollisionWithObstacle()
    {
        collectableManager.OnCollisionWithObstacle();
    }
    
    public void CollisionWithGate()
    {
        collectableManager.OnChangeMeshOnGate();
        //collectableManager.OnChangeCollectableState();
    }


}
