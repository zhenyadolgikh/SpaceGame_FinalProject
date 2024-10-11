using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject uiPanel;


    public SoundManager soundManager;
    //t
    // Start is called before the first frame update
    void Start()
    {
        //hide ui window from the start
        ShowHideUI(false);
        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        //show cursor on stat is false
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayNextSequence()
    {
        soundManager.PlaySequence();
    }

    public void SequenceWasCorrect()
    {
        Debug.Log("Sequence was correct.");
    }

    public void ShowHideUI(bool isVisible)
    {
        uiPanel.SetActive(isVisible);
    }
}
