using Assets.Scripts.Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _levelMenu;
    public GameObject AudioManager;

    private void Start()
    {
        AudioManager = GameObject.FindObjectOfType<AudioManager>().gameObject;
        AudioManager.GetComponent<AudioManager>().PlaySound("BackgroundSound");
    }

    public void ChangeMenuAfterAnimation()
    {
        StartCoroutine(WaitAndChangeMenu());
    }

    IEnumerator WaitAndChangeMenu()
    {
        yield return new WaitForSeconds(2);
        _levelMenu.SetActive(true);
    }

    public void ClearData()
    {
        var levelData = GameObject.FindObjectOfType<LevelManager>();
        levelData.LevelsInfo = new Dictionary<int, bool>();

        var levelButtons = GameObject.FindObjectOfType<LevelButtons>();
        var buttonsArray = levelButtons.LevelButtonsArray;
        foreach (var button in buttonsArray)
        {
            var data = button.GetComponent<LevelButton>();
            if (data.Level.LevelNumber == 1)
            {
                data.Level.IsBlocked = false;
            }
            else
            {
                data.Level.IsBlocked = true;
            }
        }
    }
}
