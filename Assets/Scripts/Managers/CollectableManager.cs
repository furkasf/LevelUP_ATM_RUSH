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
        
        public void CollisionWithStack()
        {
            CollectableSignals.Instance.onCollissionWithStack?.Invoke(gameObject);
            ScoreSignals.Instance.onChangePlayerScore?.Invoke((int)gameObject.GetComponent<CollectableManager>().StateData);
        }

        public void CollisionWithGate()
        {
            ChangeCollectableState(StateData);
        }
        public void CollisionWithAtm()
        {
            CollectableSignals.Instance.onCollisionWithAtm?.Invoke(transform.GetSiblingIndex(), (int)StateData);
        }
        public void CollisionWithCollectable(GameObject gO) 
        {
            CollectableSignals.Instance.onCollisionWithCollectable?.Invoke(gO);
            ScoreSignals.Instance.onChangePlayerScore?.Invoke((int)gO.GetComponent<CollectableManager>().StateData);
        }

        public void CollisionWithObstacle()
        {
            CollectableSignals.Instance.onCollisionWithObstacle?.Invoke(transform.GetSiblingIndex());
            ScoreSignals.Instance.onChangePlayerScore?.Invoke(-(int)StateData);
        }

        public void CollisionWithBand()
        {
            CollectableSignals.Instance.onCollisionWithBand?.Invoke(transform.GetSiblingIndex(),(int)StateData);
        }

        private void ChangeCollectableState(CollectableTypes _collectableTypes)
        {
            if (_collectableTypes == CollectableTypes.Money)
            {
                StateData = CollectableTypes.Gold; // get-set yazılabilir,statedata üzerinden enumun değerini gönder
                collectableMeshController.SetMeshType(1);
                ScoreSignals.Instance.onChangePlayerScore?.Invoke((int)StateData -1);
            }
        
            else if(_collectableTypes == CollectableTypes.Gold)
            {
                StateData = CollectableTypes.Diamond;
                collectableMeshController.SetMeshType(2);
                ScoreSignals.Instance.onChangePlayerScore?.Invoke((int)StateData -1);
            }
        }
    
    }
}
