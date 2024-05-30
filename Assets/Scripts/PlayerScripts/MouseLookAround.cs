using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookAround : MonoBehaviour
{
    [SerializeField] float sensitivity=2f;

    float xRotation;
    float yRotation;
    public bool ShowMouseCursor= false;

    private void Start()
    {
        Debug.Log("wywyo³anie start");
        if(ShowMouseCursor == false)
        {
            Cursor.visible = false;
            Debug.Log(Cursor.visible);
        }
    }
    void Update()
    {
        xRotation -= Input.GetAxis("Mouse Y") * sensitivity;
        yRotation += Input.GetAxis("Mouse X") * sensitivity;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);             // to stop the player from looking above/below 90

        transform.localEulerAngles = new Vector3(xRotation, yRotation, 0);
    }
}
