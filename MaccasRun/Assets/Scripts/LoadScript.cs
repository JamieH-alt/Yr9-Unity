using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LoadScript : MonoBehaviour
{
    
    [Header("Sounds")]
    [SerializeField] private AudioMixer audioMixer;

    void OnApplicationQuit()
    {
        SavePrefs();
    }

    void Awake()
    {
        LoadPrefs();
    }

    // Start is called before the first frame update
    public void SavePrefs()
    {
        float musicvol;
        audioMixer.GetFloat("Music", out musicvol);
        PlayerPrefs.SetFloat("MusicVol",musicvol);
        float fxvol;
        audioMixer.GetFloat("FX", out fxvol);
        PlayerPrefs.SetFloat("FXVol", fxvol);
        float mstrvol;
        audioMixer.GetFloat("Master", out mstrvol);
        PlayerPrefs.SetFloat("MstrVol", mstrvol);
        PlayerPrefs.Save();
    }

    public void LoadPrefs()
    {
        audioMixer.SetFloat("Music", PlayerPrefs.GetFloat("MusicVol"));
        audioMixer.SetFloat("FX", PlayerPrefs.GetFloat("FXVol"));
        audioMixer.SetFloat("Master", PlayerPrefs.GetFloat("MstrVol"));
        float vol;
        audioMixer.GetFloat("Music", out vol);
    }
}
