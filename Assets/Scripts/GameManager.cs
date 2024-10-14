using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject uiPanel;
    public GameObject winPanel;
    public SoundManager soundManager;

    private int totalSequences = 3;
    private int completedSequences = 0;
    private bool isGameWon = false; 

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
    void Update()
    {
        //if game is won, stop further interactions
        if (isGameWon)
        {
            return;
        }
    }

    //checking if completed
    public void CheckWinCondition()
    {
        Debug.Log("Checking win condition...");
        if (completedSequences >= totalSequences)
        {
            GameWon();
        }
    }

   //win 
    private void GameWon()
    {
        isGameWon = true;
        Debug.Log("You Win!");
        //Show WinPanel
        winPanel.gameObject.SetActive(true);
        //show cursor
        Cursor.visible = true;
        //unlock mouse
        Cursor.lockState = CursorLockMode.None;
    }


    public void PlayNextSequence()
    {
        //if game is not over play further
        if (!isGameWon)
        {
            soundManager.PlaySequence();
        }
    }

    public void SequenceWasCorrect()
    {
        Debug.Log("Sequence was correct.");
        completedSequences++;
        Debug.Log("Completed sequences: " + completedSequences);

        //hides the panel
        ShowHideUI(false);
        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;

        if (completedSequences >= totalSequences)
        {
            GameWon(); // Call GameWon if all sequences are completed
        }
    }

    public void ShowHideUI(bool isVisible)
    {
        uiPanel.SetActive(isVisible);
    }
}
