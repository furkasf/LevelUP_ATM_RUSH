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
            other.tag = "Collected";
            CollisionWithCollectable(other.transform.parent.gameObject);
            Debug.Log("Collectable Collision!");
        }

        if (other.CompareTag("Obstacle"))
        {
            CollisionWithObstacle();
        }

        if (other.CompareTag("Stack"))
        {
            other.tag = "Untagged";
            gameObject.tag= "Collected";
            CollisionWithStack();
            Debug.Log("Stack collision!");
        }
    }
    private void CollisionWithAtm()
    {
        collectableManager.OnCollisionWithAtm();
    }

    private void CollisionWithCollectable(GameObject gameObject)
    {
        collectableManager.OnCollisionWithCollectable(gameObject);
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
