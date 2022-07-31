using System.Collections;
using Managers;
using Enums;
using Signals;
using DG.Tweening;
using UnityEngine;

public class MinigameStartCommand 
{   
  
    public IEnumerator StartMiniGame(int score, GameObject _fakePlayer)
    {
        
        yield return new WaitForSeconds(1f);
        
        _fakePlayer.gameObject.SetActive(true);
        
        
        CoreGameSignals.Instance.onSetCameraState?.Invoke(CameraStates.Runner);

        for (int i = 0; i < score; i++)
        {
            GameObject obj = MoneyPoolManager.instance.GetMoneyFromPool();
            obj.SetActive(true);
            obj.transform.position = _fakePlayer.transform.position;
            obj.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
            obj.transform.SetParent(null);
            _fakePlayer.transform.DOMoveY(.75f, 0.1f).SetRelative(obj.transform);
            yield return new WaitForSeconds(0.09f);
        }

        //update Score

        CoreGameSignals.Instance.onSaveGameData(SaveStates.Score, score);
        
        UISignals.Instance.onChangeScoreText(score);

        UISignals.Instance.onOpenPanel(UIPanels.WinPanel);
        
    }
}
