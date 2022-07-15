using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class CollectableCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if(other.CompareTag("Obstical"))
        {
            int nextIndex = transform.GetSiblingIndex();
            int currentindex = nextIndex - 1;
            
            StackManager.Instance.RemoveFromStack(nextIndex);
            Debug.Log("trigger");
        }
    }
}
