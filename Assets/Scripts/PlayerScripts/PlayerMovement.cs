using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Camera eyesCamera;
    void Start()
    {
        eyesCamera = Camera.main;
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
        Debug.Log(horizontalInput);
        Debug.Log(verticalInput);
    }
    private void MovePlayer()
    {
        if (verticalInput != 0 && horizontalInput != 0)
        {
            moveDirection = verticalInput* orientation.forward * moveSpeed + horizontalInput*orientation.right * moveSpeed;
            transform.position += new Vector3(moveDirection.x, 0f, moveDirection.z);
        }
        else
        {
            moveDirection = verticalInput * orientation.forward * moveSpeed + horizontalInput * orientation.right * moveSpeed;
            transform.position += new Vector3(moveDirection.x, 0f, moveDirection.z);
        }
    }
    
}