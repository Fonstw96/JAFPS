using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProgress : MonoBehaviour
{
    public Image imCurrent;
    public Image imMax;
    private static int iProgress;
    public int iMax;

    void Start()
    {
        UpdateProgress();
    }

    void UpdateProgress()
    {
        imCurrent.rectTransform.sizeDelta = new Vector2(48 * iProgress, 48);
        imMax.rectTransform.sizeDelta = new Vector2(48 * iMax, 48);
    }

    public void ChangeProgress(int iNewProgress)
    {
        iProgress = iNewProgress;
        iProgress = Mathf.Clamp(iProgress, 0, iMax);

        UpdateProgress();
    }

    // I hate getters&setters, this just happens to be a workaround >:-(
    public int GetProgress()
    {
        return iProgress;
    }
}
