using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Managers
{
    public class StackManager : MonoBehaviour
    {
        public static StackManager Instance;
        #region Self Variables
        #region public
        public List<UnityEngine.Transform> Collectables = new List<UnityEngine.Transform>();
        public int AtmScore;
        public int Gamescore;
        public float LERP_SPEED = 2.5f;
        public float SCALE_MULTIPLIER = .1f;
        public float SCALE_DURATION = .2f;
        public float JUMP_RADIUS;

        private Tween scaleTween;
        #endregion
        #endregion

        private void Awake()
        {
            if(Instance == null) Instance = this;
        }

        private void Update()
        {
            LerpTheStack();
            
        }
    
        private void FixedUpdate()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("is in trigger" +
                      "");
            if (other.gameObject.GetComponent<StackData>().Type == StackData.StackType.UnStack)
            {
              
                AddOnStack(other);
            }
        }
        
        private void ShakeScaleOfStack(Transform transform)
        {
             if (scaleTween != null)
                 scaleTween.Kill(true);
             
             scaleTween = transform.DOPunchScale(Vector3.one * SCALE_MULTIPLIER, SCALE_DURATION, 1);
             
        }

        IEnumerator HandleShakeOfStack()
        {
            for (int i = 0; i < Collectables.Count; i++)
            { 
                ShakeScaleOfStack(Collectables[i].transform);
                yield return new WaitForSeconds(0.3f);
            }
     
        }


        public void RemoveFromStack(int index) 
        {
            for(int i = index; i < transform.childCount; i--)
            {
                //Collectables[index].parent = null;
                Collectables[i].GetComponent<StackData>().Type = StackData.StackType.UnStack;
                Collectables[i].gameObject.SetActive(false);
                // Collectables.RemoveAt(index);
            }
        }

        private void AddOnStack(Collider other)
        {   
            
            foreach(UnityEngine.Transform i in Collectables)
            {
                //int index = 0;
                i.transform.Translate(Vector3.forward);
                // ShakeScaleOfStack(index);
                
                // index++;
   
            }

            other.gameObject.GetComponent<StackData>().Type = StackData.StackType.Stack;
            other.transform.parent = transform;
            other.transform.localPosition = Vector3.forward;
            Collectables.Add(other.gameObject.transform);
            StartCoroutine(HandleShakeOfStack());

        }

        private void LerpTheStack()
        {
            if (Collectables is null)
            {
                return;
            }
 
      // Debug.Log("Lerp!");
      // Collectables[i].transform.position = Vector3.Lerp(new Vector3 (Collectables[i].transform.position.x, 0, 0),
      //     new Vector3(Collectables[i-1].transform.position.x * 2, 0,0),
      //     LERP_SPEED * Time.deltaTime);
       for (int i = this.transform.childCount-1; i >= 1; i--)
          {
           this.transform.GetChild(i).transform
               .DOMoveX(this.transform.GetChild(i - 1).transform.position.x, .1f);
       }
        // for (int i = 1; i <= Collectables.Count; i++)
        // {
        //    Collectables[i].transform.DOMoveX(Collectables[i - 1].transform.position.x, 0.1f);
        // }

      // for (int i = Collectables.Count-1; i >=1; i--)
      // {
      //     Collectables[i].transform.position = Vector3.Lerp(Collectables[i].transform.position,Collectables[i-1].transform.position,
      //         Time.deltaTime * LERP_SPEED);
      //     
      // }
            
        }

        private void StartMiniGame(int GameScore)
        {
            
        }

        private void CalculateScoreWithType()
        {

        }
    
    }
}