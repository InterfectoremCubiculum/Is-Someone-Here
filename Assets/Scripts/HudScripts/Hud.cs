using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    static GameObject PressText;
    static GameObject SleepPressText;
    public static void ShowPressText()
    {
        PressText.SetActive(true);
    }
    public static void HidePressText()
    {
        PressText.SetActive(false);
    }
    public static void ShowSleepPressText()
    {
        SleepPressText.SetActive(true);
    }
    public static void HideSleepPressText()
    {
        SleepPressText.SetActive(false);
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
        SleepPressText = GameObject.Find("/HudCanvas/SleepPressText");
        SleepPressText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
