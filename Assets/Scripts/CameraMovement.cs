using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //sensitivity of mouse
    public float mouseSensitivity = 100f;
    //vertical rotation
    private float verticalRotation = 0f;
    private Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        //lock the cursor so it doesn't leave the game window
       Cursor.lockState = CursorLockMode.Locked;
       //reference to player
       playerBody = transform.parent;

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
        //limits to prevent flipping upside down
        //verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        //apply the vertical rotation by modifying the local rotation of the camera
        transform.localRotation = Quaternion.Euler(verticalRotation, transform.localEulerAngles.y, 0f);
    }
}
