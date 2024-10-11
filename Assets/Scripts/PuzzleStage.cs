using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStage : MonoBehaviour
{
    public GameManager gameManager;
    public SoundManager soundManager;
    public List<int> targetSequence = new List<int> {0, 2, 3};


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //check collider
        if (other.CompareTag("Player"))
        {
            soundManager.UpdateTargetSequence(targetSequence);

            //show ui window when player touches trigger
            gameManager.ShowHideUI(true);
            //show cursor
            Cursor.visible = true;
            //unlock mouse
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //hide ui window when player leaves trigger
            gameManager.ShowHideUI(false);
            //lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            //show cursor on stat is false
            Cursor.visible = false;
        }
    }
}
