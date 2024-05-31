using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BedScript : MonoBehaviour
{
    private bool nearBed = false;
    private Animator animDead;
    private bool sleeped = false;
    private bool eyelidsOpenned = false;
    // Start is called before the first frame update
    void Start()
    {
        animDead = GameObject.Find("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sleeped) 
        {
            if(!(animDead.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f))
            {
                SceneManager.LoadScene("Death");
                return;
            }
            else if (eyelidsOpenned == false && animDead.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f) 
            {
                eyelidsOpenned = true;
                Hud.openEyelids();
                return;
            }
        }

        else if (Input.GetKeyDown(KeyCode.E) && nearBed == true)
        {
            if (Hud.GetMarks() != 0)
            {
                Debug.Log("nie oznaczy³eœ anomali");
                DyingInBed();
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
                        DyingInBed();
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
            if (eyelidsOpenned == false)
            {
                nearBed = true;
                Hud.ShowSleepPressText();
                Hud.closeEyelids();
            }
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

    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
    void DyingInBed() 
    {
        Hud.SetShouldActive(false);
        Hud.HideSleepPressText();
        animDead.enabled = true;
        animDead.SetBool("dyingInBed", true);
        sleeped = true;
    }

}
