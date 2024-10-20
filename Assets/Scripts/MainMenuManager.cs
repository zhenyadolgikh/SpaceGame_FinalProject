using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    //loads scene GAME
    public void OnPlayButton ()
    {
        SceneManager.LoadScene(1);
    }

    //loads scene MENU
    public void LoadScene ()
    {
        SceneManager.LoadScene(0);
    }
}
