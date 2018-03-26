using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int iNextLevel = -1;
    public GameObject goUserInterface;

    private UIProgress csUserInterface;

    private void Start()
    {
        csUserInterface = goUserInterface.GetComponent<UIProgress>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (iNextLevel < 0)
                print("Game over!");
            else
            {
                csUserInterface.ChangeProgress(iNextLevel);
                SceneManager.LoadScene(iNextLevel);
            }
        }
    }
}
