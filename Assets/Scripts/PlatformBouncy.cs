using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBouncy : MonoBehaviour
{
    public float fBouncePower = 600;

    private void OnCollisionEnter(Collision collision)
    {
        // For readability
        GameObject other = collision.gameObject;

        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().Bounce(fBouncePower);
        }
    }
}
