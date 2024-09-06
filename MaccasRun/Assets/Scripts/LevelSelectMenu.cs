using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : MonoBehaviour
{
    [SerializeField] private List<GameObject> container;
    [SerializeField] private List<int> levels;
    
    [SerializeField] private GameObject levelSelect;
    [SerializeField] private GameObject mainUi;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void Back()
    {
        mainUi.SetActive(true);
        levelSelect.SetActive(false);
    }

    void Update()
    {
        for (int x = 1; x < container.Count; x++)
        {
            int i = levels[x - 1];
            
            if (NextLevel.instance.beatLevels.Count < x)
            {
                container[x].transform.Find("Locked").gameObject.SetActive(true);
                container[x].transform.Find(container[x].transform.name).gameObject.SetActive(false);
                continue;
            }
            
            if (NextLevel.instance.beatLevels[(i).ToString()])
            {
                container[x].transform.Find("Locked").gameObject.SetActive(false);
                container[x].transform.Find(container[x].transform.name).gameObject.SetActive(true);
            }
        }
    }
}
