using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject uiWindow;
    public GameObject player;

    void Start()
    {
        //hide ui window from the start
        uiWindow.SetActive(false);
    }

    //trigger zone
    private void OnTriggerEnter(Collider other)
    {
        //check collider
        if (other.CompareTag("Player"))
        {
            //show ui window when player touches trigger
            uiWindow.SetActive(true);
        }
    }

    //exit trigger zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //hide ui window when player leaves trigger
            uiWindow.SetActive(false);
        }
    }
}
