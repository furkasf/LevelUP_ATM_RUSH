using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables
    
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Animator animator;
    

    #endregion

    #region Private Variables

    #endregion

    #endregion
    

    public void ActivatePlayerMovementAnimation()
    {
       animator.SetBool("isRunning",true);
       Debug.Log("isRunning TRUE!");
    }

    public void DeactivatePlayerMovementAnimation()
    {
        animator.SetBool("isRunning",false);
        Debug.Log("isRunning FALSE!");
    }
    

    public void ActivatePlayerDance()
    {
        //Dance
    }
}
