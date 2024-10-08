using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject panel;
    //array list of sounds
    public AudioClip[] noteSounds = new AudioClip[7];
    //sequence 1
    private int[] sequenceOne = new int[] {0, 2, 3};
    //player input
    private int[] playerSequenceOne = new int[3];
    private int currentNoteIndex = 0;
    private int playerNoteIndex = 0;

    //BUTTON TEST
    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        //hide panel on start
        panel.SetActive(false);
        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        //hide cursor 
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //which key for which note
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnNoteButtonPress(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OnNoteButtonPress(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OnNoteButtonPress(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            OnNoteButtonPress(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            OnNoteButtonPress(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            OnNoteButtonPress(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            OnNoteButtonPress(6);
        }
        //activate button on enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            playButton.onClick.Invoke();
        }
    }
    public void PlaySequence()
    {
        //show panel
        panel.SetActive(true);
        //unlock mouse
        Cursor.lockState = CursorLockMode.None;
        //show coursor
        Cursor.visible = true;
        //player sequence reset
        playerNoteIndex = 0;

        //play sequence
        StartCoroutine(PlayNoteSequence());
        //see if sequence played
        Debug.Log("playing sequence");
    }
    //coroutine to play sequence one note at a time
    IEnumerator PlayNoteSequence()
    {
        for (int i = 0; i < sequenceOne.Length; i++)
        {
            int noteIndex = sequenceOne[i];
            //play note
            audioSource.PlayOneShot(noteSounds[noteIndex]);
            //timing between notes
            yield return new WaitForSeconds(1f);
        }

        //players input
        currentNoteIndex = 0;
    }


    //players input when key is pressed
    public void PlayerInput(int inputNote)
    {
        //store players input in player sequence array
        playerSequenceOne[playerNoteIndex] = inputNote;

        // Check if player input matches the predefined sequence
        if (playerSequenceOne[playerNoteIndex] == sequenceOne[currentNoteIndex])
        {
            currentNoteIndex++;
            playerNoteIndex++;

            // If player completes the sequence, they win
            if (currentNoteIndex >= sequenceOne.Length)
            {
                Debug.Log("Completed");
                ResetCursor();
            }
        }
        else
        {
            Debug.Log("Wrong");
            //reset player input
            playerNoteIndex = 0;
            //reset check for instance
            currentNoteIndex = 0;
        }
    }

    //method when number keys are pressed
    public void OnNoteButtonPress(int noteIndex)
    {
        PlayerInput(noteIndex);
    }
    public void ResetCursor()
    {
        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        //hide coursor
        Cursor.visible = false;
        //hide panel
        panel.SetActive(false);
    }
}