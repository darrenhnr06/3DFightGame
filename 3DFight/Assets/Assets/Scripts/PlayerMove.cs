using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController charController;

    public float movement_Speed = 3f;
    public float gravity = 9.8f;
    public float rotation_Speed = 0.15f;
    public float rotateDegreesPerSecond = 180f;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        if(Input.GetAxis(Axis.VERTICAL_AXIS)>0)
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_Speed * Time.deltaTime);
        }
        else if (Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)
        {
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_Speed * Time.deltaTime);
        }
    }



}
