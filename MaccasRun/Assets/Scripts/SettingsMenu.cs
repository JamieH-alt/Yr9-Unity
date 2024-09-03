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
