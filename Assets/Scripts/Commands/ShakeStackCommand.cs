﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Commands
{
    public class ShakeStackCommand
    {
        private List<GameObject> _collectables;

        public ShakeStackCommand(ref List<GameObject> Collectables)
        {
            _collectables = Collectables;
        }

        public IEnumerator HandleShakeOfStack()
        {   
            
            for (int i = _collectables.Count - 1; i >= 0; i--)
            {
                if (i == 0 || i >= _collectables.Count)
                {
                    yield break;
                }
                _collectables[i].transform.DOScale(new Vector3(1.7f, 1.7f, 1.7f), 0.14f).SetEase(Ease.Flash);
                _collectables[i].transform.DOScale(Vector3.one, 0.14f).SetDelay(0.14f).SetEase(Ease.Flash);
                _collectables.TrimExcess();
                yield return new WaitForSeconds(0.05f);
            }
            
        }
    }
}
