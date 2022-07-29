using Cinemachine;
using Managers;
using Enums;
using Signals;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    #region Self Variables

    #region Serialized Variables

    public CinemachineVirtualCamera virtualCamera;
    public CinemachineVirtualCamera MiniGameCamera;
    public Animator animator;

    #endregion

    #region Private Variables

    [SerializeField] private Vector3 _initialPosition;

    private CameraStates _currentState = CameraStates.Initial;
    #endregion

    #endregion

    #region Event Subscriptions

    private void Awake()
    {
        //virtualCamera = GetComponent<CinemachineVirtualCamera>();
        animator = GetComponent<Animator>();
        //OnSetCameraState(_currentState);
        GetInitialPosition();
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onPlay += SetCameraTarget;
        CoreGameSignals.Instance.onSetCameraState += OnSetCameraState;
        CoreGameSignals.Instance.onSetCameraTarget += OnSetCameraTarget;
        CoreGameSignals.Instance.onReset += OnReset;
    }

    private void UnsubscribeEvents()
    {
        CoreGameSignals.Instance.onPlay -= SetCameraTarget;
        CoreGameSignals.Instance.onSetCameraState -= OnSetCameraState;
        CoreGameSignals.Instance.onSetCameraTarget -= OnSetCameraTarget;
        CoreGameSignals.Instance.onReset -= OnReset;
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    #endregion


    private void GetInitialPosition()
    {
        _initialPosition = transform.localPosition;
    }

    private void OnMoveToInitialPosition()
    {
        transform.localPosition = _initialPosition;
    }

    private void SetCameraTarget()
    {
        CoreGameSignals.Instance.onSetCameraTarget?.Invoke();
    }

    private void OnSetCameraTarget()
    {
        var playerManager = FindObjectOfType<PlayerManager>().transform;
        virtualCamera.Follow = playerManager;
        //virtualCamera.LookAt = playerManager;
    }

    private void OnReset()
    {
        virtualCamera.Follow = null;
        virtualCamera.LookAt = null;
        OnMoveToInitialPosition();
    }

    public void OnSetCameraState(CameraStates state)
    {
        if(state == CameraStates.Initial)
        {
            _currentState = CameraStates.Runner;
            animator.Play("RunnerCam");
        }
        else if(state == CameraStates.Runner)
        {
            _currentState = CameraStates.MiniGame;
            var playerManager = FindObjectOfType<PlayerManager>().transform;
            MiniGameCamera.Follow = playerManager; 
            var pos = new Vector3(-5, 6, 10);
            MiniGameCamera.m_Follow.position = pos;
            MiniGameCamera.LookAt= playerManager;
            animator.Play("MiniGameCam");
        }
    }

}
