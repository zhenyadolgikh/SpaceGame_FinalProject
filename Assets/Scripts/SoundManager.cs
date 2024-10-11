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
    private List<int> currentSequence;
    private int currentSequenceId;

    //sequence 1
    private List<int> sequenceOne = new List<int> {0, 2, 3};
    private List<int> sequenceTwo = new List<int> {0, 0, 1};
    private List<int> sequenceThree = new List<int> {6, 4, 5, 1};
    //player input
    private List<int> playerSequenceOne = new List<int>() {-1, -1, -1};
    private int currentNoteIndex = 0;
    private int playerNoteIndex = 0;

    //BUTTON TEST
    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        currentSequenceId = 1;
        currentSequence = sequenceOne;
    }

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
        //player sequence reset
        playerNoteIndex = 0;

        //play sequence
        StartCoroutine(PlayNoteSequence(currentSequence));
        //see if sequence played
        Debug.Log("laying sequence" + currentSequenceId);
    }
    //coroutine to play sequence one note at a time
    IEnumerator PlayNoteSequence(List<int> targetSequence)
    {
        for (int i = 0; i < targetSequence.Count; i++)
        {
            int noteIndex = targetSequence[i];
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

        //check if players input matches sequence
        if (playerSequenceOne[playerNoteIndex] == currentSequence[currentNoteIndex])
        {
            currentNoteIndex++;
            playerNoteIndex++;

            //if sequence is right
            //HERE pause before playing next sequence
            if (currentNoteIndex >= currentSequence.Count)
            {
                Debug.Log("Completed");

                currentSequenceId = 2;
                currentSequence = sequenceTwo;
                PlaySequence();
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
        if (noteIndex >= 0 && noteIndex < noteSounds.Length)
        {
            audioSource.PlayOneShot(noteSounds[noteIndex]);
            Debug.Log("Playing: " + noteIndex); 
        }
        PlayerInput(noteIndex);
    }
    
}