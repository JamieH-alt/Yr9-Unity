using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private GameObject _ui;
    [SerializeField] private GameObject _disableUi;
    [SerializeField] private AudioClip _won;
    [SerializeField] private AudioMixerGroup _FX;
    void OnTriggerEnter2D(Collider2D target) {
        if (target.gameObject.CompareTag("Finish")) {
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
