using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int iNextLevel = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (iNextLevel < 0)
                print("Game over!");
            else
                SceneManager.LoadScene(iNextLevel);
        }
    }
}
