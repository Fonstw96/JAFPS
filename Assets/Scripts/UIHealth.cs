using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public GameObject goPlayer;
    public Image[] imHealthbars;

    private PlayerHealth csPlayer;

	void Start ()
    {
        csPlayer = goPlayer.GetComponent<PlayerHealth>();
	}
	
	void Update ()
    {
        ShowHP();
	}

    void ShowHP()
    {
        // For readability
        float curHP = csPlayer.fCurHP;

        // Actual showing HP
        if (curHP >= 2)
        {
            imHealthbars[0].color = Color.white;
            imHealthbars[0].rectTransform.sizeDelta = new Vector2(90, 72);

            imHealthbars[1].color = Color.white;
            imHealthbars[1].rectTransform.sizeDelta = new Vector2(90, 72);
        }
        else if (curHP > 1)
        {
            imHealthbars[0].color = Color.white;
            imHealthbars[0].rectTransform.sizeDelta = new Vector2(90, 72);

            imHealthbars[1].color = new Color32(255, 191, 191, 255);
            imHealthbars[1].rectTransform.sizeDelta = new Vector2(90, 72 * (curHP - 1));
        }
        else
        {
            imHealthbars[0].color = new Color32(255, 191, 191, 255);
            imHealthbars[0].rectTransform.sizeDelta = new Vector2(90, 72 * curHP);

            imHealthbars[1].rectTransform.sizeDelta = new Vector2(0, 0);
        }
    }
}
