using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public PanelEnd PanelEnd;
    public PanelMain PanelMain;
    public CanvasGroup mainPanel;
    public CanvasGroup gamePanel;
    public CanvasGroup endPanel;
    public bool isStart = false;
    #region Singleton 

    public static UIManager instance = null;
    public void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion


    public void Start()
    {
        PanelActive(mainPanel, true);
        PanelActive(gamePanel, false);
        PanelActive(endPanel, false);
    }
    public void StartGame()
    {
        PanelActive(mainPanel, false);
        PanelActive(gamePanel, true);
        PanelActive(endPanel, false);
        isStart = true;

    }
    public void FixedUpdate()
    {
        PanelMain.IsStart();
    }
    public void EndGame(bool isSuccess)
    {
        PanelActive(gamePanel, false);
        PanelActive(endPanel, true);
        PanelEnd.End(isSuccess);
    }
    public void PanelActive(CanvasGroup group, bool active, float duration = 0)
    {
        if (active)
        {
            group.gameObject.SetActive(true);
            group.DOFade(1f, duration);
        }
        else
        {
            group.DOFade(0f, duration).OnComplete(() => { group.gameObject.SetActive(false); });
        }
    }

    public void SetActivePanel(CanvasGroup group, bool active)
    {
        if (active) group.alpha = 1f;
        else group.alpha = 0f;
    }

}

