using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    //sensitivity of mouse
    public float mouseSensitivity = 600f;
    //vertical rotation
    private float verticalRotation = 0f;
    private Transform playerBody;

    //reference to sensitivity slider
    public Slider sensitivitySlider;

    // menu panel on escp
    public GameObject gameMenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        //lock the cursor so it doesn't leave the game window
       Cursor.lockState = CursorLockMode.Locked;
       //reference to player
       playerBody = transform.parent;
       //sensativ slider
        if (sensitivitySlider != null)
        {
            sensitivitySlider.value = mouseSensitivity;
            sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
        }
        //panel deactive
        gameMenuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //move input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //rotate camera horizontally following mouse
        playerBody.Rotate(Vector3.up * mouseX);

        //vertical rotation
        verticalRotation -= mouseY;
        //to prevent flipping upside down
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(verticalRotation, transform.localEulerAngles.y, 0f);

        //PANEL menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameMenuPanel.SetActive(!gameMenuPanel.activeSelf);

            if (gameMenuPanel.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
    //slider value changes update
    public void OnSensitivityChanged(float newValue)
    {
        mouseSensitivity = newValue;
    }
}
