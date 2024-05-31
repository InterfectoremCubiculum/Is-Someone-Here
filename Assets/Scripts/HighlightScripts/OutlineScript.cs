using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    private Transform player;
    private Transform highlight;
    private RaycastHit raycastHit;
    public static List<Transform> selections = new List<Transform>(); // lista wybranych rzeczy
    private int maxSelections = 3;
    public float maxSelectionRange;
    public AudioSource selectSound;
    public AudioSource openSound;
    public AudioSource closedSound;
    public static List<Transform> GetSelections() { return selections; }
    public static void CleanSelection()
    {
        selections.Clear();
    }
    public void SetMaxSelections(int maxSelections)
    {
        this.maxSelections = maxSelections;
    }

    void Start()
    {
        player = Camera.main.transform;
        maxSelectionRange = 3;
    }

    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit)) // Make sure you have EventSystem in the hierarchy before using EventSystem
        {
            if (Hud.IsActive()) { Hud.HidePressText(); }
            highlight = raycastHit.transform;
            float distance = Vector3.Distance(player.position, highlight.position);

            if ((highlight.CompareTag("Door") || highlight.CompareTag("Selectable") || highlight.CompareTag("Interactive")|| highlight.CompareTag("ClosedDoor")) && !selections.Contains(highlight) && distance <= maxSelectionRange)
            {
                if (highlight.CompareTag("Door"))
                {
                    Hud.ShowPressText();
                    Animator anim = highlight.gameObject.GetComponent<Animator>();
                    if (Input.GetKeyDown("e"))
                    {
                        openSound.Play();
                        anim.StopPlayback();
                        anim.SetBool("isOpen_Obj_1", !anim.GetBool("isOpen_Obj_1"));
                    }
                    highlight = null;
                }
                else if (highlight.CompareTag("ClosedDoor"))
                {
                    Hud.ShowPressText();
                    if (Input.GetKeyDown("e"))
                    {
                        closedSound.Play();
                    }
                    highlight = null;
                }
                else if (highlight.CompareTag("Interactive"))
                {
                    Hud.ShowPressText();
                    if (Input.GetKeyDown("e"))
                    {
                        
                    }
                    highlight = null;
                }
                else 
                {
                    Outline outline = highlight.gameObject.GetComponent<Outline>();
                    if (outline != null)
                    {
                        outline.enabled = true;
                        outline.OutlineColor = Color.magenta;
                    }
                    else
                    {
                        outline = highlight.gameObject.AddComponent<Outline>();
                        outline.enabled = true;
                        outline.OutlineColor = Color.magenta;
                        outline.OutlineWidth = 7.0f;
                    }
                }
            }
            else
            {
                highlight = null;
            }
        }

        // Selection
        if (Input.GetMouseButtonDown(0))
        {
            if (highlight)
            {
                float distance = Vector3.Distance(player.position, highlight.position);
                if (distance <= maxSelectionRange && selections.Count < maxSelections) // je¿eli mniej ni¿ max wybranych 
                {
                    // dodaj now¹ selekcje
                    selectSound.Play();
                    Hud.SetMarks(Hud.marks - 1);
                    selections.Add(highlight);
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                    highlight.gameObject.GetComponent<ObjectInfo>().SetIsSelected(true);
                    highlight = null;
                }
            }
            else
            {
                // Je¿eli ju¿ klineliœmy na dany obiekt to usun go z wybranych
                if (Physics.Raycast(ray, out raycastHit))
                {
                    Transform clickedObject = raycastHit.transform;
                    if (selections.Contains(clickedObject)) // jezeli wybrane zawieraj¹ dany obiekt
                    {
                        // to usun
                        selectSound.Play();
                        Hud.SetMarks(Hud.marks + 1);
                        selections.Remove(clickedObject);
                        clickedObject.gameObject.GetComponent<ObjectInfo>().SetIsSelected(false);
                        clickedObject.gameObject.GetComponent<Outline>().enabled = false;
                    }
                }
            }
        }
    }
}