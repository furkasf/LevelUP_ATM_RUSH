using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        #endregion
        #endregion

        private void Awake()
        {
            if(Instance == null) Instance = this;
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

        private void ShakeScaleOfStack()
        {

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
                i.transform.Translate(Vector3.forward);
            }

            other.gameObject.GetComponent<StackData>().Type = StackData.StackType.Stack;
            other.transform.parent = transform;
            other.transform.localPosition = Vector3.forward;
            Collectables.Add(other.gameObject.transform);
        }

        private void LerpTheStack()
        {

        }

        private void StartMiniGame(int GameSocre)
        {
            //add The stack equal to score
        }

        private void CalculateScoreWithType()
        {

        }
    
    }
}