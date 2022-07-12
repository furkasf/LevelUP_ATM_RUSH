using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    #region Self Variables
    #region Public Variables
    public CollectableStateData CollectableStateData;



    #endregion
    #region Serialized Variables
    [SerializeField] private CollectablePhysicsController collectablePhysicsController;
    [SerializeField] private CollectableMeshConroller collectableMeshController;

    #endregion
    #region Private Variables

    #endregion


    #endregion

    private void Awake()
    {
        CollectableStateData = GetCollectableStateData();
    }



    private  CollectableStateData GetCollectableStateData()
    {

       return Resources.Load<CD_Collectables>("Data/CD_Collectable").collectableStateData;

    }


    #region Event Subscription

    private void OnEnable()
    {
        SubscribeEvents();

    }

    private void SubscribeEvents()
    {
        
    }
    private void UnsubscribeEvents()
    {

    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }


    #endregion

    private void OnChangeMeshOnGate()
    {

    }

    private void OnCollisionWithAtm()
    {

    }
    private void OnCollisionWithCollectable()
    {

    }

    private void OnCollisionWithObstacle()
    {

    }

    private void OnChangeCollectableState()
    {

    }

}
