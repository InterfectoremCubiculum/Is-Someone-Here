using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Timer.SetTime(Hud.LevelsTimes[Hud.GetCurrent()]);
            SceneManager.LoadScene(Hud.Levels[Hud.GetCurrent()]);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("Manual");
        }
    }
}