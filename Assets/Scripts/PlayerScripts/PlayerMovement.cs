using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed= 0.05f;
    public float runSpeed = 0.2f;
    public int speedTime = 2;
    float speedTimeLeft;
    Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Camera eyesCamera;
    void Start()
    {
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
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.LeftShift) && speedTimeLeft>0)
        {
            moveDirection = verticalInput * orientation.forward * runSpeed + horizontalInput * orientation.right * runSpeed;
            transform.position += new Vector3(moveDirection.x, 0f, moveDirection.z);
            speedTimeLeft -= Time.deltaTime;
        }
        else
        {
            moveDirection = verticalInput * orientation.forward * moveSpeed + horizontalInput * orientation.right * moveSpeed;
            transform.position += new Vector3(moveDirection.x, 0f, moveDirection.z);
        }
    }
    
}
