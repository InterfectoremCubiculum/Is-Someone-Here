using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BedScript : MonoBehaviour
{
    private bool nearBed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && nearBed == true)
        {
            //spradzam czy nie gine potem spanie
            int next = Hud.GetCurrent() + 1;

            if (next == Hud.Levels.Count)
            {
                SceneManager.LoadScene("Winner");
            }
            else
            {
                Hud.SetCurrent(next);
                SceneManager.LoadScene("Sleeping");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nearBed = true;
            Hud.ShowSleepPressText();
            Hud.closeEyelids();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nearBed = false;
            Hud.openEyelids();
            Hud.HideSleepPressText();
        }
    }

}
