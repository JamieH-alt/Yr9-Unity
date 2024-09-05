using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject _disableUi;
    [SerializeField] private AudioClip _won;
    [SerializeField] private AudioMixerGroup _FX;
    
    private TimeSpan topTime;
    
    public static NextLevel instance;

    public Dictionary<string, bool> beatLevels = null;
    public Dictionary<string, TimeSpan> times = null;

    void Awake() 
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    public void LoadData(GameData data)
    {
        times = data.times;
        beatLevels = data.beat;
        string _id = SceneManager.GetActiveScene().buildIndex.ToString();
        if (times.ContainsKey(_id))
        {
            topTime = times[_id];
        }
        else
        {
            topTime = TimeSpan.MaxValue;
        }
    }

    public void SaveData(ref GameData data)
    {
        times = data.times;

        string _id = SceneManager.GetActiveScene().buildIndex.ToString();
        if (topTime.TotalMilliseconds > stopWatch.instance.milliSeconds())
        {
            times[_id] = TimeSpan.FromMilliseconds(stopWatch.instance.milliSeconds());
        }

        data.beat = beatLevels;

        data.times = times;
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.CompareTag("Finish")) {
            beatLevels[SceneManager.GetActiveScene().buildIndex.ToString()] = true;
            DataPersistentManager.instance.SaveGame();
            Time.timeScale = 0f;
            _ui.SetActive(true);
            _disableUi.SetActive(false);
            stopWatch.instance.stopTimer();
            SoundFXManager.instance.PlaySoundFXClip(_won, this.transform, _FX, 1f, 1f);
        }
    }

    public void LoadNextScene() {
        Time.timeScale = 1f;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(nextSceneIndex);
        } else {
            SceneManager.LoadScene("SplashScreen");
        }
    }

    public void LoadSameScene()
    {
        Time.timeScale = 1f;
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}
