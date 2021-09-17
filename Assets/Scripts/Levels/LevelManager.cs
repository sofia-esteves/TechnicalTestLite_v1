using Assets.Scripts.Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public bool ShowLevels=false;
    public static LevelManager instance;
    private LevelButtons LevelButtonsClass;
    private Button[] LevelButtons;
    [HideInInspector]
    public Dictionary<int, bool> LevelsInfo = new Dictionary<int, bool>();
    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        LevelButtonsClass = GameObject.FindObjectOfType<LevelButtons>();
        LevelButtons = LevelButtonsClass.LevelButtonsArray;
    }

    public void CheckAndSetButtons()
    {
        LevelButtonsClass = GameObject.FindObjectOfType<LevelButtons>();
        LevelButtons = LevelButtonsClass.LevelButtonsArray;
        for (var i = 0; i < LevelButtons.Length; i++)
        {
            if (LevelButtons[i] != null)
            {
                var levelInfo = LevelButtons[i].GetComponent<LevelButton>();

                var alreadyAdded = LevelsInfo.TryGetValue(levelInfo.Level.LevelNumber, out bool value);
                if (!alreadyAdded)
                {
                    LevelsInfo.Add(levelInfo.Level.LevelNumber, levelInfo.Level.IsBlocked);
                    if (levelInfo.Level.IsBlocked)
                    {
                        LevelButtons[i].interactable = false;
                    }
                }
                else
                {
                    if (value != levelInfo.Level.IsBlocked)
                    {
                        levelInfo.Level.IsBlocked = value;
                    }
                    if (levelInfo.Level.IsBlocked)
                    {
                        LevelButtons[i].interactable = false;
                    }
                }
            }
        }
    }
}
