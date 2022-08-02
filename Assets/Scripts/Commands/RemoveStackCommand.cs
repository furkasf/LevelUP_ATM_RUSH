using System;
using System.Collections.Generic;
using DG.Tweening;
using Managers;
using Signals;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Commands
{
    public class RemoveStackCommand
    {
        private Transform _transform;
        private GameObject _gameObject;
        private GameObject _tempHolder;
        private List<GameObject> _collectables;

        public RemoveStackCommand(Transform transform, GameObject gameObject, GameObject tempHolder, ref List<GameObject> collectables)
        {
            _transform = transform;
            _gameObject = gameObject;
            _tempHolder = tempHolder;
            _collectables = collectables;
        }

        public void OnRemoveFromStack(int index)
        {

            if (index == 0)
            {
                _transform.GetChild(0).SetParent(null);

                _collectables[0].transform.SetParent(_tempHolder.transform);

                _collectables[0].SetActive(false);

                MoneyPoolManager.Instance.AddMoneyToPool(_collectables[0]);

                _collectables.Remove(_collectables[0]);

                _collectables.TrimExcess();

                return;
            }

            for (int i = index; i < _collectables.Count; i--)
            {
                if (i < 0)  // when index lower than 0 it cause trouble(null excep.)
                {
                    return;
                }

                int randomValue = Random.Range(-3, 3);

                if (randomValue + _gameObject.transform.parent.position.x <= -2.6)
                {
                    randomValue = 0;
                }

                if (randomValue + _gameObject.transform.parent.position.x >= 2.6)
                {
                    randomValue = 0;
                }
                _collectables[i].transform.SetParent(_tempHolder.transform);

                _collectables[i].transform.GetChild(1).gameObject.tag = "Collectable";

                //MoneyPoolManager.instance.AddMoneyToPool(Collectables[0]);


                int value = (int)_collectables[i].GetComponent<CollectableManager>().StateData;
                ScoreSignals.Instance.onChangePlayerScore(-value);

                _collectables[i].transform.DOJump(_collectables[i].transform.position + new Vector3(randomValue, 0, (Random.Range(6, 12))), 4.0f, 2, 1f);

                _collectables.Remove(_collectables[i]);

            }

            _collectables.TrimExcess();

        }
    }
}
