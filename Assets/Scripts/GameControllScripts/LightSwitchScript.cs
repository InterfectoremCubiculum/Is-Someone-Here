using System.Collections;
using System.Collections.Generic;
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
        // Check for "E" key press or simulated middle click
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(2))
        {
            // Simulate a raycast from the middle of the screen
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Clicked object: " + hit.transform.name + ", Tag: " + hit.transform.tag);

                // Add any additional logic you want to execute when the switch is clicked
            }
        }
    }
}
