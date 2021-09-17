using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonBehaviour : MonoBehaviour
{
    private AudioManager audioManager;
    private LevelManager levelManager;
    public GameObject LevelsMenu;
    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (levelManager.ShowLevels)
        {
            LevelsMenu.SetActive(true);

        }
        gameObject.GetComponent<Button>().onClick.AddListener(delegate() 
        {
            audioManager.PlaySound("StartSound");
        }); 
        
    }

}
