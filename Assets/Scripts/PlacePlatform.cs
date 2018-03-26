using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlatform : MonoBehaviour
{
    public float fPlaceDistance = 12;
    public GameObject goPlatform;

	void Start ()
    {
	}
	
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
            Instantiate(goPlatform, transform.position + transform.forward * fPlaceDistance, new Quaternion());
	}
}
