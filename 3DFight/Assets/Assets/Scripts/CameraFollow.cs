using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    private void LateUpdate()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {
        //transform.position = target.position + offsetPosition;

        //transform.rotation = target.rotation;
    }
}
