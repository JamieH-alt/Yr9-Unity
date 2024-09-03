using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    
    void Awake() 
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    public void LoadData(GameData data)
    {
        Dictionary<string, TimeSpan> cool = data.times;
        string _id = SceneManager.GetActiveScene().buildIndex.ToString();
        if (cool.ContainsKey(_id))
        {
            topTime = cool[_id];
        }
        else
        {
            topTime = TimeSpan.MaxValue;
        }
    }

    public void SaveData(ref GameData data)
    {
        Dictionary<string, TimeSpan> cool = data.times;
        string _id = SceneManager.GetActiveScene().buildIndex.ToString();
        if (topTime.TotalMilliseconds > stopWatch.instance.milliSeconds())
        {
            cool[_id] = TimeSpan.FromMilliseconds(stopWatch.instance.milliSeconds());
        }
        
        print(cool[_id].ToString());
        
        data.times = cool;
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.CompareTag("Finish")) {
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
