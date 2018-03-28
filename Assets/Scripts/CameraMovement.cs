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
        // For camera stability, don't keep jumping back
        vMouseRotation = transform.rotation.eulerAngles;

        // For readability
        vMouseRotation.x -= Input.GetAxis("Mouse Y") * fMouseSensitivity;
        vPlayerRotation.y += Input.GetAxis("Mouse X") * fMouseSensitivity;

        // Prevents a nasty byug
        vMouseRotation.x = ClampAngle(vMouseRotation.x, -85, 85);

        // Actual rotation
        transform.rotation = Quaternion.Euler(vMouseRotation);
        tPlayer.rotation = Quaternion.Euler(vPlayerRotation);
    }

    // Jesse from my class made this:
    public static float ClampAngle(float a, float min, float max)
    {
        while (max < min) max += 360.0f;
        while (a > max) a -= 360.0f;
        while (a < min) a += 360.0f;

        if (a > max)
        {
            if (a - (max + min) * 0.5f < 180.0f)
                return max;
            else
                return min;
        }
        else
            return a;
    }
}
