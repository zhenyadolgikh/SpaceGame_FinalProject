using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnPlayButton ()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadScene ()
    {
        SceneManager.LoadScene(0);
    }
}
