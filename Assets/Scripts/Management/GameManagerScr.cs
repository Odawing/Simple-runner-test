using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScr : MonoBehaviour
{
    public static GameManagerScr Instance;

    public InterfaceManager interfaceManager;

    public int curLevelID;

    private void Awake()
    {
        Instance = this;
    }

    public void RestartCurLevel()
    {
        SceneManager.LoadScene(curLevelID);
    }

    public void LoadNextLevel()
    {
        if (curLevelID == SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(curLevelID + 1);
    }

    public void OnPlayerDeath()
    {
        interfaceManager.ShowGameOverPanel();
    }

    public void OnEndLevel()
    {
        interfaceManager.ShowLevelCompletedPanel();
    }
}