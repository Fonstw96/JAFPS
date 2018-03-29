using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float fSpeed = .2f;
    public float fJumpStrength = 400;
    public float fFallSpeed = 2.5f;

    private Rigidbody rb;
    private bool bAllowJump = true;

	void Start ()
	{
        rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		Walk();
        SmoothJump();
	}

    private void OnCollisionStay(Collision collision)
    {
        GameObject other = collision.gameObject;

        if (other.tag == "Surface")
            bAllowJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject other = collision.gameObject;

        if (other.tag == "Surface")
            bAllowJump = false;
    }

    void Walk()
	{
		// For readability
		Vector3 vForward = transform.forward * Input.GetAxis("Vertical") * fSpeed;
		Vector3 vSideways = transform.right * Input.GetAxis("Horizontal") * fSpeed;

        // Actual movement
        transform.position += vForward * Time.deltaTime;
		transform.position += vSideways * Time.deltaTime;
	}

    void SmoothJump()
    {
        // Just in case
        Vector3 vJump = transform.up * 0;

        if (Input.GetButtonDown("Jump") && bAllowJump)
            vJump = transform.up * fJumpStrength;

        rb.AddForce(vJump);

        // Smoother fall
        rb.velocity += Vector3.up * Physics.gravity.y * (fFallSpeed - 1) * Time.deltaTime;
    }

    public void Bounce(float fBounceStrength)
    {
        rb.AddForce(transform.up * fBounceStrength);
    }
}
