using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    static GameObject PressText;
    static GameObject SleepPressText;
    private static GameObject Eyelids;
    private static Animator animEyelids;
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
    public static void closeEyelids()
    {
        Eyelids.SetActive(true);
        animEyelids.SetTrigger("close");
    }

    public static void openEyelids()
    {
        Eyelids.SetActive(false);
        animEyelids.SetTrigger("open");
    }

    // Start is called before the first frame update
    void Start()
    {
        PressText = GameObject.Find("/HudCanvas/PressText");
        PressText.SetActive(false);
        SleepPressText = GameObject.Find("/HudCanvas/SleepPressText");
        SleepPressText.SetActive(false);
        Eyelids = GameObject.Find("/HudCanvas/Eyelids");
        animEyelids = Eyelids.gameObject.GetComponent<Animator>();
        animEyelids.cullingMode = AnimatorCullingMode.AlwaysAnimate;
        Eyelids.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
