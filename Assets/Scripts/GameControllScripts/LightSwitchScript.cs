using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LightSwitchScript : MonoBehaviour
{
    private Transform player;
    private RaycastHit raycastHit;
    public float maxSelectionRange;
    public string lightObjectName; // Public variable for the name of the light object

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
            float distance = Vector3.Distance(player.position, target.position);

            if (target.CompareTag("Switch") && distance <= maxSelectionRange)
            {
                Hud.ShowPressText();
                if (Input.GetKeyDown("e"))
                {
                    try
                    {
                        GameObject[] lightObjects = GameObject.FindGameObjectsWithTag(lightObjectName);
                        if (lightObjects != null)
                        {
                            foreach (GameObject lightObject in lightObjects)
                            {
                                Light light = lightObject.GetComponent<Light>();
                                if (light != null)
                                {
                                    light.enabled = !light.enabled;
                                }
                            }
                        }
                    }
                    catch
                    {

                    }
                    
                }
            }
        }
    }

    public void TurnOffLight()
    {
        GameObject lightObject = GameObject.Find(lightObjectName);
        if (lightObject != null)
        {
            Light light = lightObject.GetComponent<Light>();
            if (light != null)
            {
                light.enabled = false;
            }
        }
    }
}
