using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettings : MonoBehaviour
{
    [SerializeField] private GameObject mainUI;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private bool game;

    public void OpenSettingsMenu() {
        mainUI.SetActive(false);
        if (game == true) {
            Time.timeScale = 0;
        } else {
            settingsUI.SetActive(true);
        }
    }   

    public void CloseSettingsMenu() {
        settingsUI.SetActive(false);
        if (game == true) {
            Time.timeScale = 1;
        } else {
            mainUI.SetActive(true);
        }
    }
}
