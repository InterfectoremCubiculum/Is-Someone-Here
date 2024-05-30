using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{   
    static GameObject PressText;
    public static void ShowPressText()
    {
        PressText.SetActive(true);
    }
    public static void HidePressText()
    {
        PressText.SetActive(false);
    }
    public static bool IsActive() 
    {
        if (PressText != null)
        {
            return PressText.activeSelf;
        }
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        PressText = GameObject.Find("/HudCanvas/PressText");
        PressText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
