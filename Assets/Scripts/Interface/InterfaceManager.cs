using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public TextMeshProUGUI curLevelText;
    public GameObject HUDPanel, GameOverPanel, LevelCompletedPanel;

    private void Start()
    {
        curLevelText.text = (GameManagerScr.Instance.curLevelID + 1).ToString();
    }

    public void ShowGameOverPanel()
    {
        HUDPanel.SetActive(false);
        GameOverPanel.SetActive(true);
    }

    public void ShowLevelCompletedPanel()
    {
        HUDPanel.SetActive(false);
        LevelCompletedPanel.SetActive(true);
    }

    public void RestartBtn()
    {
        GameManagerScr.Instance.RestartCurLevel();
    }

    public void NextLevelBtn()
    {
        GameManagerScr.Instance.LoadNextLevel();
    }
}
