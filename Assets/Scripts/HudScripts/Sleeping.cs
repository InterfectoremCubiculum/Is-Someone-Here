using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sleeping : MonoBehaviour
{
    public string nextLevel;
    public int levelTime;

    private void Start()
    {
        nextLevel = Hud.Levels[Hud.GetCurrent()];
        levelTime = Hud.LevelsTimes[Hud.GetCurrent()];
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Timer.SetTime(levelTime);
            SceneManager.LoadScene(nextLevel);
        }
    }
}
