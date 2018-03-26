using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int iMaxHP = 2;
    private float fCurHP = 0;
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
        if (fCurHP <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else if (fCurHP < iMaxHP && fRegenTimer <= Time.time)
            fCurHP += Time.deltaTime;
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
