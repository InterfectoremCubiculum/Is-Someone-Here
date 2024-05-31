using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LightSwitchScript : MonoBehaviour
{
    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0)) // 0 is for left mouse button, you can change to other buttons if needed
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Switch"))
                {
                    Debug.Log("Clicked a switch");
                    // Add any additional logic you want to execute when the switch is clicked
                }
            }
        }
    }
}
