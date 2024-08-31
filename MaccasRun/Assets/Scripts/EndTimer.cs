using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    
    // Start is called before the first frame update
    void Start()
    {
        _text.text = String.Format(@"{0:mm\:ss\.ff}", TimeSpan.FromMilliseconds(stopWatch.instance.milliSeconds()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
