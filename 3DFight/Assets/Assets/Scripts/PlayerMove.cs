using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public AudioSource audioSource;
    public Canvas canvas;
    private int k;
    public Image[] image;
    private CharacterController charController;
    private Animator animator;
    public float movement_Speed = 3f;
    public float gravity = 9.8f;
    public float rotation_Speed = 0.15f;
    public float rotateDegreesPerSecond = 180f;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        k = 2;
    }

    private void Update()
    {
        Move();
        Rotate();
        Animate();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Warrier"))
        {
            if (k >= 0)
            {
                image[k].gameObject.SetActive(false);
            }
            k--;
            if (k < 0)
            {
                canvas.gameObject.SetActive(true);
            }
        }
    }
   
    void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("Walk", true);
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("Walk", true);
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_Speed * Time.deltaTime);
        }
        else if (!(Input.GetKey(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            animator.SetBool("Walk", false);
        }
    }

    void Rotate()
    {
        Vector3 rotation_Direction = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation_Direction = transform.TransformDirection(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation_Direction = transform.TransformDirection(Vector3.right);
        }
        if (rotation_Direction != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotation_Direction), rotateDegreesPerSecond * Time.deltaTime);
        }
    }


    void Animate()
    {
        if (Input.GetKey(KeyCode.B))
        {
            animator.SetBool("Attack1", true);
            audioSource.Play();
        }
        else if (Input.GetKey(KeyCode.N))
        {
            animator.SetBool("Attack2", true);
            audioSource.Play();

        }
        else if (Input.GetKey(KeyCode.M))
        {
            animator.SetBool("Defend", true);
            audioSource.Play();

        }
        else
        {
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);
            animator.SetBool("Defend", false);
        }

    }
}
