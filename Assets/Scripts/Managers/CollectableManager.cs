using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    #region Self Variables
    #region Public Variables
    public CollectableStateData StateData;
    public MeshStateData MeshData;



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
        Debug.Log(StateData.collectableTypes);
        MeshData = GetMeshData();
        
    }
    private void Start()
    {
        OnChangeCollectableState(StateData.collectableTypes);
        Debug.Log(StateData.collectableTypes);
    }


    private CollectableStateData GetCollectableStateData() => Resources.Load<CD_Collectables>("Data/CD_Collectables").collectableStateData;
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

    public void OnChangeMeshOnGate()
    {

    }

    public void OnCollisionWithAtm()
    {

    }
    public void OnCollisionWithCollectable()
    {

    }

    public void OnCollisionWithObstacle()
    {

    }

    public void OnChangeCollectableState(CollectableStateData.CollectableTypes _collectableTypes)
    {
        if (_collectableTypes==CollectableStateData.CollectableTypes.Money)
        {
            StateData.collectableTypes = CollectableStateData.CollectableTypes.Gold;
        }
        else if (_collectableTypes==CollectableStateData.CollectableTypes.Gold)
        {
            StateData.collectableTypes = CollectableStateData.CollectableTypes.Diamond;
        }

    }
    

}
