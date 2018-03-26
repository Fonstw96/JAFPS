using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlatform : MonoBehaviour
{
    public float fPlaceDistance = 8;
    public GameObject goPlatform;
    private LineRenderer lrLaser;

	void Start ()
    {
        lrLaser = GetComponent<LineRenderer>();
	}
	
	void Update ()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            fPlaceDistance += Input.mouseScrollDelta.y;
            fPlaceDistance = Mathf.Clamp(fPlaceDistance, 4, 12);
            lrLaser.SetPosition(1, new Vector3(0, -.4f, fPlaceDistance));
        }

            if (Input.GetButtonDown("Fire1"))
            Instantiate(goPlatform, transform.position + transform.forward * fPlaceDistance, new Quaternion());
	}
}
