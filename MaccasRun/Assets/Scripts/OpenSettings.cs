using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettings : MonoBehaviour
{
    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private bool game;
    public static OpenSettings instance;
    
    private void Awake() 
    {
        if (instance == null) 
        {
            instance = this;
        }
    }
    
    public void OpenSettingsMenu() {
        settingsUI.SetActive(true);
        if (game == true) {
            Time.timeScale = 0f;
            stopWatch.instance.stopTimer();
        } else {
            mainUI.SetActive(false);
        }
    }   

    public void CloseSettingsMenu() {
        settingsUI.SetActive(false);
        if (game == true) {
            Time.timeScale = 1f;
            stopWatch.instance.continueTimer();
        } else {
            mainUI.SetActive(true);
        }
    }
}
