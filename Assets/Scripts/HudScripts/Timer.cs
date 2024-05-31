using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    public GameObject warningText;
    private Animator animDead;
    private bool sleeped = false;

    static public float leftTime;
    static public bool finish;
    static private bool isSet = false;
    private int warningTime = 15;
    public AudioSource tickingAudio;
    public AudioSource entityAudio;

    // Start is called before the first frame update
    void Start()
    {
        animDead = GameObject.Find("Player").GetComponent<Animator>();
        warningText.SetActive(false);
        finish = false;
    }

    public static void SetTime(int t)
    {
        leftTime = t;
        finish = false;
        isSet = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (sleeped)
        {
            if (!(animDead.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f))
            {
                SceneManager.LoadScene("Death");
                return;
            }
        }

        if (isSet == false)
        {
            timerText.text = "Rozejrzyj siê";
        }
        else if(finish == false)
        {
            leftTime -= Time.deltaTime;
            int min = Mathf.FloorToInt(leftTime/60);
            int sec = Mathf.FloorToInt(leftTime%60);
            if (min == 0 && sec == warningTime)
            {
                if (!tickingAudio.isPlaying)
                {
                    tickingAudio.Play();
                }
                if (!entityAudio.isPlaying)
                {
                    entityAudio.Play();
                }
                timerText.color = Color.red;
                warningText.SetActive(true);

            }

            timerText.text = string.Format("{0:00}:{1:00}",min,sec);
            if (leftTime <= 0)
            {
                finish = true;
                timerText.text = "Smieræ";
                animDead.enabled = true;
                animDead.SetBool("dying", true);
                sleeped = true;
            }
        }
    }
}
