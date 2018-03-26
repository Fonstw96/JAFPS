using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITutorial : MonoBehaviour
{
	void Update ()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0 || Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            Destroy(gameObject);
    }
}
