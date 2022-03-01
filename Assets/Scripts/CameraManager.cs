using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float mouseX;
    public float mouseY;

    public float mouseSensitivity=100f;

    public Transform playerBody;
    public float xRotation;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; //Ëø¶¨¹â±ê
    }


    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X")* mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y")* mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
