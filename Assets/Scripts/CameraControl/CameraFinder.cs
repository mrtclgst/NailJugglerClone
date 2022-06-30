using UnityEngine;
using Cinemachine;
using System;


public class CameraFinder : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera camera1, camera2;
    public void SwitchCamera()
    {
        if (camera1.gameObject.activeInHierarchy)
        {
            camera2.gameObject.SetActive(true);
        }
        else
        {
            camera1.gameObject.SetActive(true);
            camera2.gameObject.SetActive(false);
        }
    }
}
