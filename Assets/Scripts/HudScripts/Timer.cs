using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    public GameObject warningText;
    
    static public float leftTime;
    static public bool finish;
    private int warningTime = 15;

    // Start is called before the first frame update
    void Start()
    {
        warningText.SetActive(false);
        finish = false;
        //testy
        SetTime(30);
    }

    void SetTime(int t)
    {
        leftTime = t;
        finish = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(finish == false)
        {
            leftTime -= Time.deltaTime;
            int min = Mathf.FloorToInt(leftTime/60);
            int sec = Mathf.FloorToInt(leftTime%60);
            if (min == 0 && sec == warningTime)
            {
                timerText.color = Color.red;
                warningText.SetActive(true);
            }

            timerText.text = string.Format("{0:00}:{1:00}",min,sec);
            if (leftTime <= 0)
            {
                finish = true;
                timerText.text = string.Format("STOP", min, sec);
            }
        }
    }
}
