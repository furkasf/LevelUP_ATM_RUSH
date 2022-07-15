using Managers;
using UnityEngine;

public class CollectableCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstical"))
        {
            int nextIndex = transform.GetSiblingIndex();
            int currentindex = nextIndex - 1;
            
            StackManager.Instance.RemoveFromStack(nextIndex);

        }
    }
}
