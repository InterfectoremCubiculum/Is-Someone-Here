using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public string currentLevel;
    public int levelTime;

   void Start()
    {
        currentLevel = Hud.Levels[Hud.GetCurrent()];
        levelTime = Hud.LevelsTimes[Hud.GetCurrent()];
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Timer.SetTime(levelTime);
            OutlineSelection.CleanSelection();
            SceneManager.LoadScene(currentLevel);
        }
    }
}
