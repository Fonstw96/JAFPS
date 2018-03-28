using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float fSpeed = .2f;
    public float fJumpStrength = 400;
    public float fFallSpeed = 1.5f;

    private Rigidbody rb;

	void Start ()
	{
        rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		Walk();
        SmoothJump();
	}

	void Walk()
	{
		// For readability
		Vector3 vForward = transform.forward * Input.GetAxis("Vertical") * fSpeed;
		Vector3 vSideways = transform.right * Input.GetAxis("Horizontal") * fSpeed;

		// Actually moving
		transform.position += vForward * Time.deltaTime;
		transform.position += vSideways * Time.deltaTime;
	}

    void SmoothJump()
    {
        // Just in case
        Vector3 vJump = transform.up * 0;

        if (Input.GetButtonDown("Jump"))
            vJump = transform.up * fJumpStrength;

        rb.AddForce(vJump);

        // Smoother fall
        rb.velocity += Vector3.up * Physics.gravity.y * fFallSpeed * Time.deltaTime;
    }
}
