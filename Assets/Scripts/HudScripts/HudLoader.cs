using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudLoader : MonoBehaviour
{
    public Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;
        SceneManager.LoadScene("HudScene", LoadSceneMode.Additive);
    }
}
