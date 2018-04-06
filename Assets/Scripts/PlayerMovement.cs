using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float fSpeed = .2f;
    public float fJumpStrength = 400;
    public float fFallSpeed = 2.5f;
    public float fJumpHelp = .6f;

    private Rigidbody rb;
    private bool bAllowJump = true;
    private AudioSource asJump;

	void Start ()
	{
        rb = GetComponent<Rigidbody>();
        asJump = GetComponent<AudioSource>();
	}

	void Update ()
	{
		Walk();
        SmoothJump();
	}

    private void OnCollisionStay(Collision collision)
    {
        GameObject other = collision.gameObject;
        float fDifference = other.transform.position.y - transform.position.y;

        if (fDifference > 0 && fDifference < fJumpHelp)
            transform.position = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);

        if (other.tag != "NoJump")
            bAllowJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject other = collision.gameObject;

        if (other.tag != "NoJump")
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
        {
            vJump = transform.up * fJumpStrength;
            asJump.Play();
        }

        rb.AddForce(vJump);

        // Smoother fall
        rb.velocity += Vector3.up * Physics.gravity.y * (fFallSpeed - 1) * Time.deltaTime;
    }

    public void Bounce(float fBounceStrength)
    {
        rb.AddForce(transform.up * fBounceStrength);
    }
}
