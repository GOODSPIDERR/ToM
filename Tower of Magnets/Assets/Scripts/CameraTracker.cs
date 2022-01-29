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

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    }


    void Update()
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

    void SwitchState(int currentState)
    {
        switch (currentState)
        {
            case 1:
                transposer.m_FollowOffset = new Vector3(0, -10, -15);
                break;
            case 2:
                transposer.m_FollowOffset = new Vector3(0, -5, -15);
                break;
            case 3:
                transposer.m_FollowOffset = new Vector3(0, 0, -15);
                break;
            case 4:
                transposer.m_FollowOffset = new Vector3(0, 5, -15);
                break;
            case 5:
                transposer.m_FollowOffset = new Vector3(0, 10, -15);
                break;
        }
    }
}
