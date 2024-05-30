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

    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit)) // Make sure you have EventSystem in the hierarchy before using EventSystem
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Selectable") && !selections.Contains(highlight))
            {
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    outline.OutlineColor = Color.magenta;
                    outline.OutlineWidth = 7.0f;
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
                if (selections.Count < maxSelections) // je�eli mniej ni� max wybranych 
                {
                    // dodaj now� selekcje
                    selections.Add(highlight);
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                    highlight = null;
                }
            }
            else
            {
                // Je�eli ju� klineli�my na dany obiekt to usun go z wybranych
                if (Physics.Raycast(ray, out raycastHit))
                {
                    Transform clickedObject = raycastHit.transform;
                    if (selections.Contains(clickedObject)) // jezeli wybrane zawieraj� dany obiekt
                    {
                        // to usun
                        selections.Remove(clickedObject);
                        clickedObject.gameObject.GetComponent<Outline>().enabled = false;
                    }
                }
            }
        }
    }
}