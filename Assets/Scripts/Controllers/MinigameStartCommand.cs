using System.Collections;
using System.Collections.Generic;
using Managers;
using Enums;
using Signals;
using DG.Tweening;
using UnityEngine;

public class MinigameStartCommand 
{
    public IEnumerator StartMiniGame(int score, Transform _transform)
    {

        _transform.rotation = new Quaternion(0, 180, 0, 0);
        CoreGameSignals.Instance.onSetCameraState?.Invoke(CameraStates.Runner);

        for (int i = 0; i < score; i++)
        {
            GameObject obj = MoneyPoolManager.instance.GetMoneyFromPool();
            obj.SetActive(true);
            obj.transform.position = _transform.position;
            obj.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
            obj.transform.SetParent(null);
            // DOVirtual.DelayedCall(5, () => transform.DOMoveY(1, 0.5f).SetRelative(obj.transform));
            _transform.DOMoveY(1, 0.1f).SetRelative(obj.transform);
            yield return new WaitForSeconds(0.09f);
            Debug.Log("index : " + i);
        }
    }
}
