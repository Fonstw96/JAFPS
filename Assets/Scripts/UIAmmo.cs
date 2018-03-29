using UnityEngine;
using UnityEngine.UI;

public class UIAmmo : MonoBehaviour
{
    public GameObject goPlacer;
    public Text[] tAmmos;
    public Image goCursor;

    private PlacePlatform csPlayer;
    private int iCurAmmo = 0;

    void Start ()
    {
        csPlayer = goPlacer.GetComponent<PlacePlatform>();
	}

	void Update ()
    {
        ChangeCursor();
        ChangeAmmo();
    }

    void ChangeCursor()
    {
        // For readability
        int curY = 12 + csPlayer.iCurAmmo * 48;
        //print(curY);

        // Actually changing position
        goCursor.rectTransform.anchoredPosition = new Vector2(-12, -curY);
    }

    void ChangeAmmo()
    {
        int i = 0;
        foreach (Text ammo in tAmmos)
        {
            // For readability
            int currentAmmo = csPlayer.iAmmo[i];

            // Actaully change text
            ammo.text = currentAmmo.ToString();
            i++;
        }
    }
}
