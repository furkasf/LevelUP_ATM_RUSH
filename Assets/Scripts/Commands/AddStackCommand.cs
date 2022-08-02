using System;
using System.Collections.Generic;
using Keys;
using UnityEngine;

namespace Commands
{
    public class AddStackCommand
    {
        private AddStackKeyParams _params;

        public AddStackCommand(AddStackKeyParams param)
        {
            _params = param;
        }

        public void OnAddOnStack(GameObject gO)
        {

            foreach (var i in _params._collectables)
            {
                i.transform.Translate(Vector3.forward);
            }

            gO.transform.parent = _params._transform;

            gO.transform.localPosition = Vector3.forward;

            _params._collectables.Add(gO);

            _params._monoBehaviour.StartCoroutine(_params._shakeStackCommand.HandleShakeOfStack());

        }
    }
}
