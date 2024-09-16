using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider _FX;
    [SerializeField] private Slider _Master;
    [SerializeField] private Slider _Music;
    
    [Header("CRT")]
    [SerializeField] private Button _CRT;

    [SerializeField] private Sprite _CRT_Active;
    [SerializeField] private Sprite _CRT_Inactive;

    [SerializeField] private GameObject _CRTVolume;

    public bool CRTActive = true;

    public static SettingsMenu instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start() {
        float music;
        audioMixer.SetFloat("Music", PlayerPrefs.GetFloat("MusicVol"));
        audioMixer.GetFloat("Music", out music);
        _Music.value = music;
        float master;
        audioMixer.SetFloat("Master", PlayerPrefs.GetFloat("MstrVol"));
        audioMixer.GetFloat("Master", out master);
        _Master.value = master;
        float fx;
        audioMixer.SetFloat("FX", PlayerPrefs.GetFloat("FXVol"));
        audioMixer.GetFloat("FX", out fx);
        _FX.value = fx;
        if (CRTToggleScript.instance.CRTActive && CRTActive == false) {
            CRTToggle();
        }
        if (!CRTToggleScript.instance.CRTActive && CRTActive) {
            CRTToggle();
        }
    }
    
    public void CRTToggle()
    {
        if (CRTActive)
        {
            _CRT.image.sprite = _CRT_Inactive;
            CRTActive = false;
        }
        else
        {
            _CRT.image.sprite = _CRT_Active;
            CRTActive = true;
        }
        CRTToggleScript.instance.CRTVolume(CRTActive);
        DataPersistentManager.instance.SaveGame();
    }

    public void SetMusicVolume() {
        float volume = _Music.value;
        audioMixer.SetFloat("Music", volume);
        PlayerPrefs.SetFloat("MusicVol", volume);
    }

    public void SetMasterVolume() {
        float volume = _Master.value;
        audioMixer.SetFloat("Master", volume);
        PlayerPrefs.SetFloat("MstrVol", volume);
    }

    public void SetFXVolume() {
        float volume = _FX.value;
        audioMixer.SetFloat("FX", volume);
        PlayerPrefs.SetFloat("FXVol", volume);
    }
}
