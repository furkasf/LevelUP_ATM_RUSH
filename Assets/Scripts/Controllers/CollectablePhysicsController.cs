using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

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

        if (other.CompareTag("Gate"))
        {
            CollisionWithGate();
        }

        if (other.CompareTag("Collectable"))
        {
            CollisionWithCollectable();
        }

        if (other.CompareTag("Obstacle"))
        {
            CollisionWithObstacle();
        }

        if (other.CompareTag("Stack"))
        {
            CollisionWithStack();
        }
    }
    private void CollisionWithAtm()
    {
        collectableManager.OnCollisionWithAtm();
    }

    private void CollisionWithCollectable()
    {
        collectableManager.OnCollisionWithCollectable();
    }

    private void CollisionWithObstacle()
    {
        collectableManager.OnCollisionWithObstacle();
    }
    
    private void CollisionWithGate()
    {
        collectableManager.OnCollisionWithGate();
    }

    private void CollisionWithStack()
    {
        collectableManager.OnCollisionWithStack();
    }

}
