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
            if (Hud.GetMarks() != 0)
            {
                Debug.Log("nie oznaczy³eœ anomali");
                SceneManager.LoadScene("Death");
                return;
            }
            else
            {
                List<Transform> lista = OutlineSelection.GetSelections();
                foreach (Transform s in lista)
                {
                    ObjectInfo obj = s.gameObject.GetComponent<ObjectInfo>();
                    if (obj.isAnomaly != true)
                    {
                        Debug.Log("nie znalaz³eœ wszystkich anomali");
                        SceneManager.LoadScene("Death");
                        return;
                    }
                }
            }

            int next = Hud.GetCurrent() + 1;
            if (next == Hud.Levels.Count)
            {
                Debug.Log("to by³ ostatni poziom");
                SceneManager.LoadScene("Winner");
                return;
            }
            else
            {
                Hud.SetCurrent(next);
                Debug.Log("znalaz³eœ wszystkie anomalie");
                SceneManager.LoadScene("Sleeping");
                return;
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
