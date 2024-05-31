using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    static GameObject PressText;
    static GameObject MarksText;
    static GameObject CurrentLevelText;

    static GameObject SleepPressText;
    private static GameObject Eyelids;
    private static Animator animEyelids;

    //public static List<string> Levels = new List<string>() {"Level0","Level1","Level2"};
    public static List<string> Levels = new List<string>() { "Home", "Home", "Home"};
    public static List<int> LevelsTimes = new List<int>() {3600,60,30};
    public static int current = 0;
    public static int marks;

    public static void SetCurrent(int c)
    {
        current = c;
        TextMeshProUGUI textInside = CurrentLevelText.GetComponent<TextMeshProUGUI>();
        textInside.text = "Poziom: " + Levels[current];
    }
    public static int GetCurrent()
    {
        return current;
    }
    public static void SetMarks(int m)
    {
        marks = m;
        TextMeshProUGUI textInside = MarksText.GetComponent<TextMeshProUGUI>();
        textInside.text = "Oznaczenia: "+marks;
        if(marks == 0)
        {
            textInside.color = Color.red;
        }
        else
        {
            textInside.color = Color.white;
        }
    }
    public static int GetMarks()
    {
        return marks;
    }
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
        animEyelids.SetTrigger("Close");
    }

    public static void openEyelids()
    {
        //Eyelids.SetActive(false);
        animEyelids.SetTrigger("Open");
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
        MarksText = GameObject.Find("/HudCanvas/MarksText");
        CurrentLevelText = GameObject.Find("/HudCanvas/CurrentLevelText");
        SetCurrent(current);
        SetMarks(3);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
