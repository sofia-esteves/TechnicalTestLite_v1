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
}
