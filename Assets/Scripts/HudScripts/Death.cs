using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public string currentLevel = "HomeLozko";
    public int levelTime = 20;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Timer.SetTime(levelTime);
            SceneManager.LoadScene(currentLevel);
        }
    }
}
