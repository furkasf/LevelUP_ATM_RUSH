using System;
using Data.ValueObject;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    #region Self Variables
    #region Public Variables
    public CollectableTypes StateData;
    public MeshStateData MeshData;

    public GameObject go;


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
        MeshData = GetMeshData();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            OnCollisionWithGate();
        }
    }

    private CollectableTypes GetCollectableStateData() => Resources.Load<CD_Collectables>("Data/CD_Collectables").collectableStateData.collectableTypes;
    private MeshStateData GetMeshData() => Resources.Load<CD_Collectables>("Data/CD_Collectables").meshState;
    


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

    public void SendCollectableStateDataToControllers()
    {
        collectableMeshController.SetMeshType(MeshData.meshType);
    }

    public void OnCollisionWithGate()
    {
        OnChangeCollectableState(StateData);
    }
    public void OnCollisionWithAtm()
    {
        // Invoke RemoveStack && score
        // pass the StateData value
    }
    public void OnCollisionWithCollectable()
    {
        //Invoke AddStack
    }

    public void OnCollisionWithObstacle()
    {
        // Invoke RemoveStack
    }

    public void OnChangeCollectableState(CollectableTypes _collectableTypes)
    {
        if (_collectableTypes == CollectableTypes.Money)
        {
            StateData = CollectableTypes.Gold;
        }
        
        else if(_collectableTypes == CollectableTypes.Gold)
        {
            StateData = CollectableTypes.Diamond;
        }
    }
    
}
