using Controllers;
using Data.ValueObject;
using Signals;
using UnityEngine;

namespace Managers
{
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


        public void CollisionWithStack()
        {
            CollectableSignals.Instance.onCollissionWithStack?.Invoke(this.gameObject);
        }

        public void CollisionWithGate()
        {
            ChangeCollectableState(StateData);
        }
        public void CollisionWithAtm()
        {
            CollectableSignals.Instance.onCollisionWithAtm?.Invoke(transform.GetSiblingIndex());
            // pass the StateData value
        }
        public void CollisionWithCollectable(GameObject gO) // private and -On
        {
            CollectableSignals.Instance.onCollisionWithCollectable?.Invoke(gO);
        }

        public void CollisionWithObstacle()
        {
            CollectableSignals.Instance.onCollisionWithObstical?.Invoke(transform.GetSiblingIndex());
        }

        private void ChangeCollectableState(CollectableTypes _collectableTypes)
        {
            if (_collectableTypes == CollectableTypes.Money)
            {
                StateData = CollectableTypes.Gold; // get-set yazılabilir,statedata üzerinden enumun değerini gönder
                collectableMeshController.SetMeshType(1);
            
            }
        
            else if(_collectableTypes == CollectableTypes.Gold)
            {
                StateData = CollectableTypes.Diamond;
                collectableMeshController.SetMeshType(2);
            
            }
        }
    
    }
}
