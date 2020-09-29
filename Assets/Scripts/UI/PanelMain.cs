using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PanelMain : MonoBehaviour
{
    public MainPanel startpanel;
    private float bottomPos;
    // Start is called before the first frame update
    void Start()
    {
        bottomPos = startpanel.toptostart.anchoredPosition.y;
        SetOutPanel(startpanel);
        
    }

    public void IsStart()
    {
        Appear(startpanel);
    }
    private void Appear(MainPanel panel)
    {
        panel.toptostart.DOAnchorPosY(bottomPos, 0.5f);

    }
    private void SetOutPanel(MainPanel panel)
    {
        panel.toptostart.anchoredPosition -= new Vector2(0, 1000f);

    }
}
[System.Serializable]
public struct MainPanel
{
    public RectTransform toptostart;
}