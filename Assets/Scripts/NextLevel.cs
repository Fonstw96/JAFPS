using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int iNextLevel = -1;
    public GameObject goUserInterface;

    private UIProgress csUserInterface;
    private AudioSource asPhase;
    private float fTeleportTimer;

    void Start()
    {
        csUserInterface = goUserInterface.GetComponent<UIProgress>();
        asPhase = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (fTeleportTimer > 0 && fTeleportTimer < Time.time)
            SceneManager.LoadScene(iNextLevel);
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
                asPhase.Play();
                fTeleportTimer = Time.time + .7f;
            }
        }
    }
}
