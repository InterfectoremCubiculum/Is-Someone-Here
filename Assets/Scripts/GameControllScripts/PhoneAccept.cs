using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhoneAccept : MonoBehaviour
{
    private Transform player;
    private RaycastHit raycastHit;
    public float maxSelectionRange;
    public string phoneObjectName; // Public variable for the name of the phone object
    public AudioSource ownerTalk;
    public AudioSource myTalk;
    public AudioSource myTalk2;

    void Start()
    {
        player = Camera.main.transform;
        maxSelectionRange = 3;
    }

    void Update()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            Transform target = raycastHit.transform;
            float distance = Vector3.Distance(player.position, target.position);
            if (target.CompareTag(phoneObjectName) && distance <= maxSelectionRange)
            {
                Hud.ShowPressText();
                if (Input.GetKeyDown("e"))
                {
                    GameObject phoneObject = GameObject.FindGameObjectWithTag(phoneObjectName);
                    AudioSource phone = phoneObject.GetComponent<AudioSource>();
                    phone.Stop();
                    ownerTalk.Play();
                    StartCoroutine(playSound());
                    StartCoroutine(playSound2());
                    phone.tag = "Untagged";
                }
            }
        }
    }
    IEnumerator playSound()
    {
        yield return new WaitForSeconds(28);
        myTalk.Play();
    }
    IEnumerator playSound2()
    {
        yield return new WaitForSeconds(45);
        myTalk2.Play();
    }
}
