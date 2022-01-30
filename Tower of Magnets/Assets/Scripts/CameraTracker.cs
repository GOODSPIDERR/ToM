using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DG.Tweening;

public class CameraTracker : MonoBehaviour
{
    public int currentPosition = 3;
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineTransposer transposer;
    [SerializeField] private Ease ease;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && currentPosition < 5)
        {
            currentPosition++;
            SwitchState(currentPosition);
        }

        if (Input.GetKeyDown(KeyCode.S) && currentPosition > 1)
        {
            currentPosition--;
            SwitchState(currentPosition);
        }
    }

    private void SwitchState(int currentState)
    {
        switch (currentState) //not the most efficient way to write this, but it works
        {
            case 1:
                DOTween.To(()=> transposer.m_FollowOffset, x=> transposer.m_FollowOffset = x, new Vector3(0, -10, -15), 0.25f).SetEase(ease);
                break;
            case 2:
                DOTween.To(()=> transposer.m_FollowOffset, x=> transposer.m_FollowOffset = x, new Vector3(0, -5, -15), 0.25f).SetEase(ease);
                break;
            case 3:
                DOTween.To(()=> transposer.m_FollowOffset, x=> transposer.m_FollowOffset = x, new Vector3(0, 0, -15), 0.25f).SetEase(ease);
                break;
            case 4:
                DOTween.To(()=> transposer.m_FollowOffset, x=> transposer.m_FollowOffset = x, new Vector3(0, 5, -15), 0.25f).SetEase(ease);
                break;
            case 5:
                DOTween.To(()=> transposer.m_FollowOffset, x=> transposer.m_FollowOffset = x, new Vector3(0, 10, -15), 0.25f).SetEase(ease);
                break;
        }
    }
}
