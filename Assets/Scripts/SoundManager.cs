using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    //HERE
    public ParticlesManager particlesManager;

    public GameManager gameManager;
    public AudioSource audioSource;
    //array list of sounds
    public AudioClip[] noteSounds = new AudioClip[7];
    public List<int> currentSequence;


    //player input
    private List<int> playerSequence;
    private int currentNoteIndex = 0;
    private int playerNoteIndex = 0;

    //BUTTON TEST
    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {

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

    public void UpdateTargetSequence(List<int> desiredTargetSequence)
    {
        currentSequence = desiredTargetSequence;
        playerSequence = new List<int>();
        for (int i = 0; i<desiredTargetSequence.Count; i++)
            playerSequence.Add(-1);
    }

    public void PlaySequence()
    {
        //player sequence reset
        playerNoteIndex = 0;

        //play sequence
        StartCoroutine(PlayNoteSequence(currentSequence)); // ToDo: Reference currentSequence from GameManager
        //see if sequence played
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
        playerSequence[playerNoteIndex] = inputNote;

        //check if players input matches sequence
        if (playerSequence[playerNoteIndex] == currentSequence[currentNoteIndex])
        {
            currentNoteIndex++;
            playerNoteIndex++;

            //if sequence is right
            //HERE pause before playing next sequence
            if (currentNoteIndex >= currentSequence.Count)
            {
                Debug.Log("Completed");
                gameManager.SequenceWasCorrect(); //also add the flower function
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