using System;
using System.Collections.Generic;
using Data.ValueObject;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    #region Self Variables
    #region Public Variables
    public CollectableTypes StateData;

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
        
        StateData = GetCollectableStateData();
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            OnCollisionWithGate();
        }
    }

    private CollectableTypes GetCollectableStateData() => Resources.Load<CD_Collectables>("Data/CD_Collectables").collectableStateData.collectableTypes;





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


    public void OnCollisionWithStack()
    {
        CollectableSignals.Instance.onCollissionWithStack?.Invoke(this.gameObject);
    }

    public void OnCollisionWithGate()
    {
        OnChangeCollectableState(StateData);
    }
    public void OnCollisionWithAtm()
    {
        CollectableSignals.Instance.onCollisionWithAtm?.Invoke(transform.GetSiblingIndex());
        // pass the StateData value
    }
    public void OnCollisionWithCollectable()
    {
        CollectableSignals.Instance.onCollisionWithCollectable?.Invoke(this.gameObject);
    }

    public void OnCollisionWithObstacle()
    {
        CollectableSignals.Instance.onCollisionWithObstical?.Invoke(transform.GetSiblingIndex());
    }

    public void OnChangeCollectableState(CollectableTypes _collectableTypes)
    {
        if (_collectableTypes == CollectableTypes.Money)
        {
            StateData = CollectableTypes.Gold;
            collectableMeshController.SetMeshType(1);
            
        }
        
        else if(_collectableTypes == CollectableTypes.Gold)
        {
            StateData = CollectableTypes.Diamond;
            collectableMeshController.SetMeshType(2);
            
        }
    }
    
}
