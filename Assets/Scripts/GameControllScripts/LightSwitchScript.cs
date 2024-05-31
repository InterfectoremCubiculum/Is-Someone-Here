using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LightSwitchScript : MonoBehaviour
{
    private Transform player;
    private RaycastHit raycastHit;
    public float maxSelectionRange;
    public GameObject lightObjectGameParent; // Public variable for the name of the light object
    public AudioSource clickSound;

    void Start()
    {
        player = Camera.main.transform;
        maxSelectionRange = 3;
    }

    void Update()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            Transform target = raycastHit.transform;
            float distance = Vector3.Distance(player.position, gameObject.transform.position);

            if (distance <= maxSelectionRange && raycastHit.collider == gameObject.GetComponent<Collider>())
            {
                Hud.ShowPressText();
                if (Input.GetKeyDown("e"))
                {
                    Debug.Log($"Wcisniêto");
                    clickSound.Play();
                    foreach (Transform light in lightObjectGameParent.GetComponent<Transform>())
                    {
                        Debug.Log($"zapalono {light.name}");
                        light.gameObject.GetComponent<Light>().enabled = !light.gameObject.GetComponent<Light>().enabled;
                    }
                    
                }
            }
        }
    }

    public void TurnOffLight()
    {
        foreach (Transform light in lightObjectGameParent.GetComponent<Transform>())
        {
            Debug.Log($"zapalono {light.name}");
            if (light.gameObject.GetComponent<Light>().enabled == true)
            {
                clickSound.Play();
                light.gameObject.GetComponent<Light>().enabled = false;
            }
        }
    }
}
