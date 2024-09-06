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
    [SerializeField] private int id;

    [Header("Level 1")] 
    [SerializeField] private Sprite icon1;
    [SerializeField] private String title1;
    [SerializeField] private String sceneName1;
    [SerializeField] private int id1;
    
    [Header("Level 2")] 
    [SerializeField] private Sprite icon2;
    [SerializeField] private String title2;
    [SerializeField] private String sceneName2;
    [SerializeField] private int id2;
    
    [Header("Level 3")] 
    [SerializeField] private Sprite icon3;
    [SerializeField] private String title3;
    [SerializeField] private String sceneName3;
    [SerializeField] private int id3;

    private Dictionary<string, TimeSpan> _times = new Dictionary<string, TimeSpan>();

    private String _currentStringName = null;
    
    
    
    public void OpenLevel(int id)
    {
        _times = NextLevel.instance.times;
        Sprite _icon = null;
        String _title = null;
        String _stringName = null;
        int _id = 0;
        if (id == 0)
        {
            _icon = icon;
            _title = title;
            _stringName = sceneName;
            _id = id;
        } else if (id == 1)
        {
            _icon = icon1;
            _title = title1;
            _stringName = sceneName1;
            _id = id1;
        } else if (id == 2)
        {
            _icon = icon2;
            _title = title2;
            _stringName = sceneName2;
            _id = id2;
        } else if (id == 3)
        {
            _icon = icon3;
            _title = title3;
            _stringName = sceneName3;
            _id = id3;
        }

        _currentStringName = _stringName;

        titletext.text = _title;
        iconImage.GetComponent<Image>().sprite = _icon;
        
        // Load Stuff Here
        if (_times.ContainsKey(_id.ToString()))
        {
            bestTime.text = String.Format(@"{0:mm\:ss\.ff}", _times[_id.ToString()]);
        }

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
