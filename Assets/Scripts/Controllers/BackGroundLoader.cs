﻿using System;
using System.Collections.Generic;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Extentions;
using Signals;
using UnityEngine;
using TMPro;

namespace Controllers
{
    public class BackGroundLoader : MonoSingleton<BackGroundLoader>
    {
        #region Self Variables

        #region Public Variables
        
        public BackGroundAxis backgroundAxis = BackGroundAxis.Vertical;

        public Transform targetTransform;
        
        
        #endregion

        #region Serialized Variables

        [SerializeField] private List<GameObject> cubeList = new List<GameObject>();
        
        [SerializeField] private int predictedCubeCount;
        
        [SerializeField] private int mostValuableObjectValue = 3;

        [SerializeField] private Transform levelCollactableHolder ;
        
        private int levelCollactableCount = 80;
        
        #endregion

        #region Private Variables

        private LetterPathData Data;
        
        private float colorValue;
            
        private Vector3 forwardStack;

        private Vector3 upwardsStack;

        private float _indexMinFactor;

        #endregion

        #endregion
        
   
        private void Awake()
        {
            Data = GetLetterPathData();
            _indexMinFactor = Data.indexMinFactor;
        }

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            MiniGameSignals.Instance.onCollisionWithBlock += SetColor;
        }

        private void UnsubscribeEvents()
        {
            MiniGameSignals.Instance.onCollisionWithBlock -= SetColor;
        }
        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        
        private void Start()
        {

            Data.cubePrefab.transform.localScale = Data.CubeScale;
            
            targetTransform.position = new Vector3(0,(Data.cubePrefab.transform.localScale.y / 2) -1f,195);

            SetCubesToScene(SetPredictedCubeCount()); 
            
            OnLoadTower(backgroundAxis); 
        }

        private LetterPathData GetLetterPathData() => Resources.Load<CD_LetterPath>("Data/CD_LetterPath").LetterPathData;
        
        private int SetPredictedCubeCount() // Set cube count base level
        {
            return predictedCubeCount = (levelCollactableCount * mostValuableObjectValue) / Data.cubeScaleFactor;
        }
        
        private void SetCubesToScene(int cubeCount)
        {
            for (int i = 0; i < cubeCount; i++)
            {
                cubeList.Add(Instantiate(Data.cubePrefab,targetTransform));
                
            }
        }
        private void SetColor(GameObject gO)
        {
            colorValue += 0.05f;
            
            if (colorValue>= 0.9f)
            {
                colorValue = 0;
            }
            
            gO.GetComponent<Renderer>().material.color = Color.HSVToRGB(colorValue, 1, 1);
        }
        private void SetTowerCollider(BackGroundAxis _backgroundAxis,GameObject gO)
        {   
            BoxCollider cubeCollider = gO.GetComponent<BoxCollider>();
            
            if (_backgroundAxis == BackGroundAxis.Vertical)
            {
                cubeCollider.center = Data.cubeColliderCenter;
                cubeCollider.size = Data.cubeColliderSize;
            }
            else
            {
                cubeCollider.center = Data.cubeColliderCenter;
                cubeCollider.size = Data.cubeColliderSize;
            }
        }
        private void SetTextOnCubes(GameObject gO,BackGroundAxis _backgroundAxis)
        {   
            
            
            if (_indexMinFactor > Data.indexMaxFactor)
            {
                return;
            }
         
            float _value = _indexMinFactor / 10;
            
            if (_backgroundAxis == BackGroundAxis.Vertical)
            {
                gO.transform.GetChild(0).gameObject.SetActive(true);
                
                gO.transform.GetChild(0).GetComponentInChildren<TextMeshPro>().text = _value.ToString() + "X";
            }
            else
            {
                gO.transform.GetChild(1).gameObject.SetActive(true);
                
                gO.transform.GetChild(1).GetComponentInChildren<TextMeshPro>().text = _value.ToString() + "X";
            }

            _indexMinFactor++;
        }
        private Vector3 SetStackDirection(BackGroundAxis _backgroundAxis,int index)
        {
            if (_backgroundAxis == BackGroundAxis.Vertical)
            {
               return forwardStack = cubeList[index].transform.localScale.y * Vector3.up;
            }
            else
            {
                return upwardsStack = cubeList[index].transform.localScale.z * Vector3.forward;
            }
        }
        private void SetBuild(BackGroundAxis _backgroundAxis)
        {
            for (int i = 0; i < cubeList.Count; i++)
            {   
                SetTextOnCubes(cubeList[i].gameObject,_backgroundAxis);
                
                SetTowerCollider(_backgroundAxis,cubeList[i]);
                
                if (i == 0)
                {
                    cubeList[i].transform.position = targetTransform.position;
                }
                else
                {
                   
                    cubeList[i].transform.position = cubeList[i - 1].transform.position + SetStackDirection(_backgroundAxis,i);
                }
            }
        }
        private void OnLoadTower(BackGroundAxis _backgroundAxis)
        {
            if (_backgroundAxis == BackGroundAxis.Vertical)
            {
                SetBuild(_backgroundAxis);
            }
            else
            {   
                SetBuild(_backgroundAxis);
            }
        }
    }
}