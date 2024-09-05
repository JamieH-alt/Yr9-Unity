using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

[System.Serializable]
public class GameData
{
    public int fries;
    public Dictionary<string, TimeSpan> times;
    public Dictionary<string, bool> beat;

    public GameData()
    {
        this.fries = 0;
        this.times = new Dictionary<string, TimeSpan>();
        this.beat = new Dictionary<string, bool>();
    }
}
