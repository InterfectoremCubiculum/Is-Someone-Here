using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    private Transform highlight;
    private RaycastHit raycastHit;
    private List<Transform> selections = new List<Transform>(); // lista wybranych rzeczy
    private int maxSelections = 3;
    public List<Transform> GetSelections() { return selections; }
    public void SetMaxSelections(int maxSelections)
    {
        this.maxSelections = maxSelections;
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
            if ((highlight.CompareTag("Selectable") || highlight.CompareTag("Interactive")) && !selections.Contains(highlight))
            {
                if (highlight.CompareTag("Interactive"))
                {
                    Hud.ShowPressText();
                    Animator anim = highlight.gameObject.GetComponent<Animator>();
                    if (Input.GetKeyDown("e"))
                    {
                        Debug.Log(anim.GetBool("isOpen_Obj_1"));
                        anim.SetBool("isOpen_Obj_1", !anim.GetBool("isOpen_Obj_1"));
                    }
                    highlight = null;
                }
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
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
                if (selections.Count < maxSelections) // je¿eli mniej ni¿ max wybranych 
                {
                    // dodaj now¹ selekcje
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
                        selections.Remove(clickedObject);
                        clickedObject.gameObject.GetComponent<ObjectInfo>().SetIsSelected(false);
                        clickedObject.gameObject.GetComponent<Outline>().enabled = false;
                    }
                }
            }
        }
    }
}