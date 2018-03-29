using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int iMaxHP = 2;
    public float fCurHP = 0;
    private float fRegenTimer = 0;
    public float fRegenDelay = 3;

    private Rigidbody rb;

    void Start ()
    {
        fCurHP = iMaxHP;

        rb = GetComponent<Rigidbody>();
	}

    void Update()
    {
        if (fCurHP < 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else if (fCurHP < iMaxHP && fRegenTimer <= Time.time)
            fCurHP += Time.deltaTime / fRegenDelay;
    }

    public void ChangeHP(int iModifier)
    {
        if (fRegenTimer <= Time.time+2)
        {
            fCurHP += iModifier;

            if (iModifier > 0)
                fRegenTimer = 0;
            else
            {
                rb.AddForce(-transform.forward * 864);
                fRegenTimer = Time.time + fRegenDelay;
            }
        }
    }
}
