using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]CinemachineVirtualCamera camera;

    private void OnEnable()
    {
        Player.OnSpawn += SetFollow;
    }
    public void SetFollow(Transform player)
    {
        camera.LookAt = player;
        camera.Follow = player;
    }  
}
