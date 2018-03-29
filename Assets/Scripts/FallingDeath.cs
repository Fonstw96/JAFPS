using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingDeath : MonoBehaviour
{
    public float fMaxFall = 108;

	void Update ()
    {
        if (transform.position.y < -fMaxFall)
        {
            if (tag == "Player")
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            else
                Destroy(gameObject);
        }
	}
}
