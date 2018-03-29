using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlatform : MonoBehaviour
{
    public float fPlaceDistance = 8;
    public GameObject[] goPlatforms;
    public int[] iAmmo;

    private LineRenderer lrLaser;
    public int iCurAmmo = 0;

    void Start ()
    {
        lrLaser = GetComponent<LineRenderer>();
	}
	
	void Update ()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            fPlaceDistance -= 1;
            if (fPlaceDistance < 4)
                fPlaceDistance = 4;

            lrLaser.SetPosition(1, new Vector3(0, -.4f, fPlaceDistance));
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            fPlaceDistance += 1;
            if (fPlaceDistance > 12)
                fPlaceDistance = 12;

            lrLaser.SetPosition(1, new Vector3(0, -.4f, fPlaceDistance));
        }
        if (Input.mouseScrollDelta.y != 0)
        {
            iCurAmmo -= (int)Input.mouseScrollDelta.y;

            // Loop current ammo
            if (iCurAmmo < 0)
                iCurAmmo += 5;
            else if (iCurAmmo > 4)
                iCurAmmo -= 5;
        }

        if (Input.GetButtonDown("Fire1") && iAmmo[iCurAmmo] > 0)
        {
            iAmmo[iCurAmmo] -= 1;
            Instantiate(goPlatforms[iCurAmmo], transform.position + transform.forward * fPlaceDistance, new Quaternion());
        }
	}
}
