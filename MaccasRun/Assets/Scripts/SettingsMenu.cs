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

    private void Awake() {
        float music;
        audioMixer.GetFloat("Music", out music);
        _Music.value = music;
        float master;
        audioMixer.GetFloat("Master", out master);
        _Master.value = master;
        float fx;
        audioMixer.GetFloat("FX", out fx);
        _FX.value = fx;
    }

    public void SetMusicVolume() {
        float volume = _Music.value;
        audioMixer.SetFloat("Music", volume);
    }

    public void SetMasterVolume() {
        float volume = _Master.value;
        audioMixer.SetFloat("Master", volume);
    }

    public void SetFXVolume() {
        float volume = _FX.value;
        audioMixer.SetFloat("FX", volume);
    }
}
