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
<<<<<<< HEAD
                if (i == 0 || i >= _collectables.Count)
                {
                    yield break;
                }
                _collectables[i].transform.DOScale(new Vector3(1.4f, 1.4f, 1.4f), 0.1f).SetEase(Ease.Flash);
                _collectables[i].transform.DOScale(Vector3.one, 0.1f).SetDelay(0.1f).SetEase(Ease.Flash);
=======
                if( i == 0 || i>= _collectables.Count)
                {
                    yield break;
                }
                _collectables[i].transform.DOScale(new Vector3(1.7f, 1.7f, 1.7f), 0.14f).SetEase(Ease.Flash);
                _collectables[i].transform.DOScale(Vector3.one, 0.14f).SetDelay(0.14f).SetEase(Ease.Flash);
>>>>>>> f5f3096225a9340d53fcd3d61c7c419c4cd44b7a
                _collectables.TrimExcess();
                yield return new WaitForSeconds(0.05f);
            }
            
        }
    }
}
