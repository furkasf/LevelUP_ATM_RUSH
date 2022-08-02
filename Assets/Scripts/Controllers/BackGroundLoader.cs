using System;
using System.Collections.Generic;
using Data.UnityObject;
using Data.ValueObject;
using Commands;
using Enums;
using Extentions;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class BackGroundLoader : MonoSingleton<BackGroundLoader>
    {
        #region Self Variables

        #region Public Variables
        
        public BackGroundAxis BackGroundAxis = BackGroundAxis.Vertical;

        public Transform TargetTransform;
        
        
        #endregion

        #region Serialized Variables

        [SerializeField] private List<GameObject> cubeList = new List<GameObject>();
        
        [SerializeField] private int predictedCubeCount;
        
        [SerializeField] private int mostValuableObjectValue = 3;

        [SerializeField] private Transform levelCollactableHolder ;
        
        private int levelCollactableCount = 80;
        
        #endregion

        #region Private Variables

        private LetterPathData _data;
        
        private float _colorValue;
            
        private Vector3 _forwardStack;

        private Vector3 _upwardsStack;

        private float _indexMinFactor;

        //commands

        private BackGroundDirectionCommand _backGroundDirectionCommand;
        private BackGroundColorCommand _backGroundColorCommand;
        private BackGroundSetColliderCommand _backGroundSetColliderCommand;
        private BackGroundTextCommand _backGroundTextCommand;
        private BackGroundBuildCommand _backGroundBuildCommand;

        #endregion

        #endregion


        private void Awake()
        {
            _data = GetLetterPathData();
            _indexMinFactor = _data.indexMinFactor;
            if(TargetTransform == null) TargetTransform = transform.GetChild(0);
            if(levelCollactableHolder == null) levelCollactableHolder = transform.parent;
            _data.cubePrefab.transform.localScale = _data.CubeScale;
            TargetTransform.position = new Vector3(0, (_data.cubePrefab.transform.localScale.y / 2) - 1f, 195);

            _backGroundDirectionCommand = new BackGroundDirectionCommand(ref _forwardStack, ref _upwardsStack, ref cubeList);
            _backGroundColorCommand = new BackGroundColorCommand(_colorValue);
            _backGroundSetColliderCommand = new BackGroundSetColliderCommand(ref _data);
            _backGroundTextCommand = new BackGroundTextCommand(ref _data, _indexMinFactor);
            _backGroundBuildCommand = new BackGroundBuildCommand(ref _backGroundTextCommand, ref _backGroundSetColliderCommand, ref _backGroundDirectionCommand, ref cubeList, TargetTransform);
        } 

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            MiniGameSignals.Instance.onCollisionWithBlock += _backGroundColorCommand.SetColor;
        }

        private void UnsubscribeEvents()
        {
            MiniGameSignals.Instance.onCollisionWithBlock -= _backGroundColorCommand.SetColor;
        }
        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        
        private void Start()
        {
            //draw tower when leve started
            SetCubesToScene(SetPredictedCubeCount());  
            OnLoadTower(BackGroundAxis); 
        }

        private LetterPathData GetLetterPathData() => Resources.Load<CD_LetterPath>("Data/CD_LetterPath").LetterPathData;
        
        private int SetPredictedCubeCount() // Set cube count base level
        {
            return predictedCubeCount = (levelCollactableCount * mostValuableObjectValue) / _data.cubeScaleFactor;
        }
        
        private void SetCubesToScene(int cubeCount)
        {
            for (int i = 0; i < cubeCount; i++)
            {
                cubeList.Add(Instantiate(_data.cubePrefab,TargetTransform));
                
            }
        }
 
        private void OnLoadTower(BackGroundAxis _backgroundAxis)
        {
            if (_backgroundAxis == BackGroundAxis.Vertical)
            {
                _backGroundBuildCommand.SetBuild(_backgroundAxis);
            }
            else
            {
                _backGroundBuildCommand.SetBuild(_backgroundAxis);
            }
        }
    }
}