using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    static GameObject PressText;
    static void ShowPressText()
    {
        PressText.SetActive(true);
    }
    static void HidePressText()
    {
        PressText.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
