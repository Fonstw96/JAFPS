using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float fSpeed = .2f;
    public float fJumpStrength = 400;
    public float fFallSpeed = 2.5f;

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
		//print("F: " + vForward + ", S: " + vSideways);

        // Actual movement
		transform.position += vForward;
		transform.position += vSideways;
	}

    void SmoothJump()
    {
        // For readability
        Vector3 vJump = transform.up * 0;

        if (Input.GetButtonDown("Jump"))
            vJump = transform.up * fJumpStrength;

        // Actual jump
        rb.AddForce(vJump);

        // Faster fall
        rb.velocity += Vector3.up * Physics.gravity.y * (fFallSpeed - 1) * Time.deltaTime;
    }
}
