using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    [SerializeField] private Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SplashScreen");
    }
}
