using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    // Start is called before the first frame update

    public float movementSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        //Look the cursor at the middle of the script
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Horizontal") * movementSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Vertical") * movementSensitivity * Time.deltaTime;


        xRotation -= mouseY;
        yRotation += mouseX;
        // Limit rotation to 180 deg so the player cant look behind their head
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        //playerBody.Rotate(Vector3.up * mouseX);
    }
}
