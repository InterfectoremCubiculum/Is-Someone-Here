using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiScrpit : MonoBehaviour
{
    public AudioSource stepsLivingRoom;
    public AudioSource stepsBathRoom;
    public AudioSource stepsGarage;
    public AudioSource stepsSleepRoom;
    public AudioSource knockingWindow;
    public AudioSource knockingDoors;
    public GameObject lightLivingRoom;
    public GameObject lightBathRoom;
    public GameObject lightGarage;
    public GameObject lightSleepRoom;
    public float eventTime = 5;
    float leftEventTime;
    int random;
    void Start()
    {
    leftEventTime = eventTime;
    }

    // Update is called once per frame
    void Update()
    {
        leftEventTime -= Time.deltaTime;
        if(leftEventTime <= 0)
        {
            random=Random.Range(0, 10);
            switch(random)
            {
                case 0:
                    stepsLivingRoom.Play();
                    break;
                case 1:
                    stepsBathRoom.Play();
                    break;
                case 2:
                    stepsGarage.Play();
                    break;
                case 3:
                    stepsSleepRoom.Play();
                    break;
                case 4:
                    knockingWindow.Play();
                    break;
                case 5:
                    knockingDoors.Play();
                    break;
                case 6:
                    LightSwitchScript light = lightLivingRoom.GetComponent<LightSwitchScript>();
                    light.TurnOffLight();
                    break;
                case 7:
                    LightSwitchScript light2 = lightBathRoom.GetComponent<LightSwitchScript>();
                    light2.TurnOffLight();
                    break;
                case 8:
                    LightSwitchScript light3 = lightGarage.GetComponent<LightSwitchScript>();
                    light3.TurnOffLight();
                    break;
                case 9:
                    LightSwitchScript light4 = lightSleepRoom.GetComponent<LightSwitchScript>();
                    light4.TurnOffLight();
                    break;
            }
            leftEventTime = 0;
            leftEventTime = eventTime;
        }
    }
}
