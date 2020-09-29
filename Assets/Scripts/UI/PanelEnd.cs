using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class PanelEnd : MonoBehaviour
{

    public EndPanel success;
    public EndPanel fail;

    private float topPos;
    private float bottomPos;
    private float alpha;
    void Start()
    {
        topPos = success.topText.anchoredPosition.y;
        bottomPos = success.bottomText.anchoredPosition.y;
        alpha = success.background.color.a;

        SetOutPanel(success);
        SetOutPanel(fail);
    }
    public void End(bool isSuccess)
    {
        if (isSuccess)
            Appear(success);
        else
            Appear(fail);
    }

    private void Appear(EndPanel panel)
    {
        panel.panel.gameObject.SetActive(true);
        panel.background.DOFade(alpha, 0.5f);
        panel.topText.DOAnchorPosY(topPos, 0.5f);
        panel.bottomText.DOAnchorPosY(bottomPos, 0.5f);
    }
    private void SetOutPanel(EndPanel panel)
    {
        panel.panel.gameObject.SetActive(false);
        Color c = panel.background.color;
        c.a = 0f;   panel.background.color = c;
        panel.background.color = c;
        panel.bottomText.anchoredPosition -= new Vector2(0, 1000f);
    }

}
[System.Serializable]
public struct EndPanel
{
    public GameObject panel;
    public RectTransform topText;
    public RectTransform bottomText;
    public Image background;
}