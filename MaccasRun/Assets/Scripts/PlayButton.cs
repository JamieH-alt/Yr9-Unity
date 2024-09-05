using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    [SerializeField] private Button playButton;
    [SerializeField] private GameObject levelSelect;
    [SerializeField] private GameObject mainUi;
    
    // Start is called before the first frame update
    void Start()
    {
        playButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick() {
        mainUi.SetActive(false);
        levelSelect.SetActive(true);
    }
}
