using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{

    [SerializeField] private Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        quitButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick() {
        Application.Quit();
    }
}
