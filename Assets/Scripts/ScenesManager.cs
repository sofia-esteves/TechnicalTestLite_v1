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
}
