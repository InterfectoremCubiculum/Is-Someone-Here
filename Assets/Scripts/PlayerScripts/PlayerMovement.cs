using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Animator anim;
    public float moveSpeed= 0.05f;
    public float runSpeed = 0.1f;
    public float speedTime = 1;
    public AudioSource moveSound;
    float speedTimeLeft;
    Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Camera eyesCamera;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        eyesCamera = Camera.main;
        orientation = eyesCamera.transform;
        speedTimeLeft = speedTime;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();   
    }

    void FixedUpdate()
    {
        if (!MovePlayer())
        {
            RegenStamina();
        }
        StaminaBar.SetStamina(speedTimeLeft, speedTime);
    }

    private void RegenStamina()
    {
        if(speedTimeLeft<speedTime)
        {
            speedTimeLeft += Time.deltaTime/4;
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    private bool MovePlayer()
    {
        if (horizontalInput!=0 || verticalInput!=0)
        {
            if (speedTimeLeft > 0 && Input.GetKey(KeyCode.LeftShift))
            {
                moveSound.clip = Resources.Load<AudioClip>("fastWalk");
                if (!moveSound.isPlaying)
                {
                    moveSound.Play();
                }
                moveDirection = verticalInput * orientation.forward * runSpeed + horizontalInput * orientation.right * runSpeed;
                transform.position += new Vector3(moveDirection.x, 0f, moveDirection.z);
                speedTimeLeft -= Time.deltaTime;
                return true;
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSound.clip = Resources.Load<AudioClip>("calmWalk");
                if (!moveSound.isPlaying)
                {
                    moveSound.Play();
                }
                moveDirection = verticalInput * orientation.forward * moveSpeed + horizontalInput * orientation.right * moveSpeed;
                transform.position += new Vector3(moveDirection.x, 0f, moveDirection.z);
                return true;
            }
            else
            {
                moveSound.clip = Resources.Load<AudioClip>("calmWalk");
                if (!moveSound.isPlaying)
                {
                    moveSound.Play();
                }
                moveDirection = verticalInput * orientation.forward * moveSpeed + horizontalInput * orientation.right * moveSpeed;
                transform.position += new Vector3(moveDirection.x, 0f, moveDirection.z);
                return false;
            }
        }
        transform.position += Vector3.zero;
        moveSound.Stop();
        return false;
    }
    
}
