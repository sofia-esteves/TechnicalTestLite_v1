using Assets.Scripts.Data;
using Assets.Scripts.Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    /// <summary>
    /// Manages Level data and presentation
    /// Gets the data stored from the Save Load class
    /// Has method Check and Set Buttons, called every time the Levels Menu is oppened or has changes
    /// Is not destroyed from scene to scene
    /// </summary>

    public bool ShowLevels=false;
    public static LevelManager instance;
    private LevelButtons LevelButtonsClass;
    private Button[] LevelButtons;

    LevelProgress LevelProgress = new LevelProgress();
    [HideInInspector]
    public Dictionary<int, bool> LevelsInfo = new Dictionary<int, bool>();
    private void Awake()
    {
        SaveLoad.Load();
        var data = SaveLoad.savedProgress;
        if (data != null)
        {
            LevelsInfo = data.LevelsInfo;
        }
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
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
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
        LevelProgress.LevelsInfo = LevelsInfo;
        LevelProgress.Current = LevelProgress;
    }
}
