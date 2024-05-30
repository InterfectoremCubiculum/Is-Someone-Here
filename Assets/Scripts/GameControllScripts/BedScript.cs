using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedScript : MonoBehaviour
{
    public float detectionRange = 10f;
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
            SceneManager.LoadScene("Sleeping");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nearBed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        nearBed = false;
    }

}
