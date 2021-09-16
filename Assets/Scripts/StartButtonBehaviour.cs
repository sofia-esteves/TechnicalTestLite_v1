using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonBehaviour : MonoBehaviour
{
    private AudioManager audioManager;
    private LevelManager levelManager;
    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        gameObject.GetComponent<Button>().onClick.AddListener(delegate() 
        {
            audioManager.PlaySound("StartSound");
            levelManager.CheckAndSetButtons();
        }); 
        
    }

}
