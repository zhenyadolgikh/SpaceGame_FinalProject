using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject uiPanel;
    public SoundManager soundManager;

    // NEW: Total number of sequences to win
    private int totalSequences = 3;
    private int completedSequences = 0;
    private bool isGameWon = false; // NEW: Track if the game is won

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
        // If game is won, stop further interactions
        if (isGameWon)
        {
            return;
        }
    }

    // NEW: Check if all sequences are completed
    public void CheckWinCondition()
    {
        Debug.Log("Checking win condition...");
        if (completedSequences >= totalSequences)
        {
            GameWon();
        }
    }

    // NEW: Called when the player wins the game
    private void GameWon()
    {
        isGameWon = true;
        Debug.Log("You Win!");
        // Optionally, trigger UI elements or transitions here to show the win screen or message
       // ShowHideUI(true); // Show UI to indicate winning state
    }


    public void PlayNextSequence()
    {
        if (!isGameWon) // Only play sequences if the game is not won
        {
            soundManager.PlaySequence();
        }
    }

    public void SequenceWasCorrect()
    {
        Debug.Log("Sequence was correct.");
        completedSequences++; // Increment the completed sequence count
        Debug.Log("Completed sequences: " + completedSequences);

        // New: Hide the panel after completing a sequence
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
