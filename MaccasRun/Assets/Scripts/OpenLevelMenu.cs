using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenLevelMenu : MonoBehaviour
{

    [Header("Global")] 
    [SerializeField] private GameObject levelOpenUi;
    [SerializeField] private GameObject levelSelectUi;
    [SerializeField] private TMP_Text titletext;
    [SerializeField] private GameObject iconImage;
    [SerializeField] private TMP_Text bestTime;
    
    [Header("Tutorial")] 
    [SerializeField] private Sprite icon;
    [SerializeField] private String title;
    [SerializeField] private String sceneName;

    [Header("Level1")] 
    [SerializeField] private Sprite icon1;
    [SerializeField] private String title1;
    [SerializeField] private String sceneName1;
    
    [Header("Level2")] 
    [SerializeField] private Sprite icon2;
    [SerializeField] private String title2;
    [SerializeField] private String sceneName2;

    private String _currentStringName = null;
    
    public void OpenLevel(int id)
    {
        Sprite _icon = null;
        String _title = null;
        String _stringName = null;
        if (id == 0)
        {
            _icon = icon;
            _title = title;
            _stringName = sceneName;
        } else if (id == 1)
        {
            _icon = icon1;
            _title = title1;
            _stringName = sceneName1;
        } else if (id == 2)
        {
            _icon = icon2;
            _title = title2;
            _stringName = sceneName2;
        }

        _currentStringName = _stringName;

        titletext.text = _title;
        iconImage.GetComponent<Image>().sprite = _icon;
        
        // Load Stuff Here
        
        levelOpenUi.SetActive(true);
        levelSelectUi.SetActive(false);
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene(_currentStringName);
    }

    public void Back()
    {
        levelOpenUi.SetActive(false);
        levelSelectUi.SetActive(true);
    }
}
