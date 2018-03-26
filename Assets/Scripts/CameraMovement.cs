using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float fMouseSensitivity = 1;
    public Transform tPlayer;
    
    private Vector3 vMouseRotation;
    private Vector3 vPlayerRotation;

    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

	void Update ()
    {
        Look();
    }

    void Look()
    {
        // For stability
        vMouseRotation = transform.rotation.eulerAngles;

        // For readability
        vMouseRotation.x -= Input.GetAxis("Mouse Y") * fMouseSensitivity;
        vPlayerRotation.y += Input.GetAxis("Mouse X") * fMouseSensitivity;

        // Actual rotation
        transform.rotation = Quaternion.Euler(vMouseRotation);
        tPlayer.rotation = Quaternion.Euler(vPlayerRotation);
    }
}
