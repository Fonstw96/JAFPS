using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBouncy : MonoBehaviour
{
    public float fBouncePower = 600;

    private AudioSource asBounce;

    void Start()
    {
        AudioSource[] allAudio = GetComponents<AudioSource>();

        foreach (AudioSource source in allAudio)
        {
            if (!source.loop)
                asBounce = source;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // For readability
        GameObject other = collision.gameObject;

        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().Bounce(fBouncePower);
            asBounce.Play();
            asBounce.Play();
        }
    }
}
