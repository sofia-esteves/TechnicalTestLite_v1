using Assets.Scripts.Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public GameObject NextLevelButton;
    private void Start()
    {
        var currentLevel = SceneManager.GetActiveScene().buildIndex;
        var levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (currentLevel == 0)
        {
            levelManager.CheckAndSetButtons();

        }

        levelManager.LevelsInfo.TryGetValue(currentLevel, out bool islocked);
        if (islocked)
        {
            NextLevelButton.SetActive(true);
        }

    }
    public void GoToLevel(int level)
    {
        SceneManager.LoadScene(level);
        var levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.ShowLevels = true;
    }
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        var levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.ShowLevels = true;
    }
    public void GoToPreviousLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        var levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.ShowLevels = true;
    }
    public void UnlockNextLevel()
    {
        var currentLevel = SceneManager.GetActiveScene().buildIndex;
        var levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LevelsInfo.Remove(currentLevel+1);
        levelManager.LevelsInfo.Add(currentLevel+1, false);
    } 
    public LevelsEnum GetCurrentLevel()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        if (index == 0)
        {
            return LevelsEnum.Main;
        }
        else if(index == 1)
        {
            return LevelsEnum.FirstLevel;
        }
        else if (index == 2)
        {
            return LevelsEnum.SecondLevel;
        }
        else
        {
            return LevelsEnum.ThirdLevel;
        }
    }
}
