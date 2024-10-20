using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //panel in puzzle stages
    public GameObject uiWindow;
    //reference to player
    public GameObject player;

    void Start()
    {
        //hide ui window from the start
        uiWindow.SetActive(false);
        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        //show cursor on stat is false
        Cursor.visible = false;
    }

    //trigger zone
    private void OnTriggerEnter(Collider other)
    {
        //check collider
        if (other.CompareTag("Player"))
        {
            //show ui window when player touches trigger
            uiWindow.SetActive(true);
            //show cursor
            Cursor.visible = true;
            //unlock mouse
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //exit trigger zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //hide ui window when player leaves trigger
            uiWindow.SetActive(false);
            //lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            //show cursor on stat is false
            Cursor.visible = false;
        }
    }
}
