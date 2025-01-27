using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Camera cameraObject;
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float smoothTime = 1.0f;
    private float xRotation;
    private float yRotation;


    void Start()
    {
        if (cameraObject == null)
        {
            cameraObject = FindAnyObjectByType<Camera>();
        }
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MouseMovement();
    }
    void MouseMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);
        Quaternion targetXRotation = Quaternion.Euler(xRotation, 0f, 0f);
        cameraObject.transform.localRotation = Quaternion.Lerp(cameraObject.transform.localRotation, targetXRotation, smoothTime);

        yRotation += mouseX;
        Quaternion targetPlayerRotation = Quaternion.Euler(0f, yRotation, 0f);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetPlayerRotation, smoothTime);
    }
}
