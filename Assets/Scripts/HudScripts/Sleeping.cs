using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sleeping : MonoBehaviour
{
    public string nextLevel;
    public int levelTime;
    private GameObject slepText;
    private void Start()
    {
        slepText = GameObject.Find("/SleepingCanvas/SleepingText");
        TextMeshProUGUI textInside = slepText.GetComponent<TextMeshProUGUI>();
        if (Hud.GetCurrent()-1 == 0)
        {
            Debug.Log("teraz");
            textInside.text = "Po obudzeniu znajdü\r\n3 anomalie i je oznacz\r\n\r\n";
        }
        else
        {
            textInside.text = "Znalaz≥eú wszystkie anomalie\r\npo wstaniu znajdü kolejne 3 anomalie\r\n\r\n";
        }
        nextLevel = Hud.Levels[Hud.GetCurrent()];
        levelTime = Hud.LevelsTimes[Hud.GetCurrent()];
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Timer.SetTime(levelTime);
            OutlineSelection.CleanSelection();
            SceneManager.LoadScene(nextLevel);
        }
    }
}
