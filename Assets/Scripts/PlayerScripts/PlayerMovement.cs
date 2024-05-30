using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed= 0.05f;
    public float runSpeed = 0.1f;
    public float speedTime = 1;
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
        if (!MovePlayer())
        {
            RegenStamina();
        }
    }

    private void RegenStamina()
    {
        if(speedTimeLeft<speedTime)
        {
            speedTimeLeft += Time.deltaTime;
            Debug.Log(speedTimeLeft);
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
            Debug.Log(speedTimeLeft);
            if (speedTimeLeft > 0 && Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection = verticalInput * orientation.forward * runSpeed + horizontalInput * orientation.right * runSpeed;
                transform.position += new Vector3(moveDirection.x, 0f, moveDirection.z);
                speedTimeLeft -= Time.deltaTime;
                return true;
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection = verticalInput * orientation.forward * moveSpeed + horizontalInput * orientation.right * moveSpeed;
                transform.position += new Vector3(moveDirection.x, 0f, moveDirection.z);
                return true;
            }
            {
                moveDirection = verticalInput * orientation.forward * moveSpeed + horizontalInput * orientation.right * moveSpeed;
                transform.position += new Vector3(moveDirection.x, 0f, moveDirection.z);
                return false;
            }
        }
        return false;
    }
    
}
