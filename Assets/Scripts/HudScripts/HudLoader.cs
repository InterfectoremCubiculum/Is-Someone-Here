using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudLoader : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("HudScene", LoadSceneMode.Additive);
    }
}
