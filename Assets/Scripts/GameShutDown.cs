using UnityEngine;

public class GameShutDown : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Fire1") || Input.GetButton("Submit") || Input.GetButton("Cancel"))
            Application.Quit();
    }
}
