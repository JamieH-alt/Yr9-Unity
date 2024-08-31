using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class stopWatch : MonoBehaviour
{

    [SerializeField] private TMP_Text text;

    private Stopwatch _time;
    public TimeSpan timeElapsed { get; private set; }

    public static stopWatch instance;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void stopTimer()
    {
        _time.Stop();
    }

    public long milliSeconds()
    {
        return _time.ElapsedMilliseconds;
    }

    // Start is called before the first frame update
    void Start()
    {
        _time = new Stopwatch();
        _time.Start();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = TimeSpan.FromMilliseconds(_time.ElapsedMilliseconds);
        text.text = String.Format(@"{0:mm\:ss\.ff}", timeElapsed);
    }
}
