using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    static private Slider staminaSlider;
    static private GameObject sliderObject;
    private void Awake()
    {
        sliderObject = GameObject.Find("/HudCanvas/StaminaBar");
        staminaSlider = sliderObject.GetComponent<Slider>();
    }
    public static void SetStamina(float stamina, float maxStamina)
    {
        if (staminaSlider != null)
        {
            staminaSlider.value = stamina / maxStamina;
            if(stamina>=maxStamina)
            {
                if (sliderObject.active == true)
                {
                    sliderObject.SetActive(false);
                }
            }
            else if (staminaSlider.value <= 0)
            {
                staminaSlider.fillRect.gameObject.SetActive(false);
            }
            else
            {
                sliderObject.SetActive(true);
                staminaSlider.fillRect.gameObject.SetActive(true);
            }
        }
        
    }
}
