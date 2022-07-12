using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePhysicsController : MonoBehaviour
{
    #region Self Variables
    #region Serializefield Variables
    [SerializeField] private CollactableManager collactableManager;
    [SerializeField] private Collider col;
    [SerializeField] private Rigidbody rb;




    #endregion


    #endregion

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void CollisionWithAtm()
    {

    }

    public void CollisionWithCollectable()
    {

    }

    public void CollisionWithObstacle()
    {

    }
    
    public void CollisionWithGate()
    {

    }


}
