using Assets.Scripts.Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void GoToLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GoToPreviousLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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
