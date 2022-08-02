using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managers;
using Signals;
using UnityEngine;

namespace Commands
{
    public class RemoveStackATMCommand
    {
        private List<GameObject> _collectables;
        private GameObject _tempHolder;

        public RemoveStackATMCommand(ref List<GameObject> collectables, GameObject tempHolder)
        {
            _collectables = collectables;
            _tempHolder = tempHolder;
        }

        public void OnCollisionWithATM(int index, int value)
        {
            if (index == 0)
            {

                _collectables[0].transform.SetParent(_tempHolder.transform);

                MoneyPoolManager.Instance.AddMoneyToPool(_collectables[0]);

                ScoreSignals.Instance.onChangeAtmScore?.Invoke(value);

                _collectables.Remove(_collectables[0]);

                _collectables.TrimExcess();

                return;
            }

        }
    }
}
