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
    public Tuple<Sprite, RuntimeAnimatorController> sprite;
    public bool CRTActive;
    
    private Sprite sprite2 = null;
    private RuntimeAnimatorController anim = null;
    
    public GameData()
    {
        this.fries = 0;
        this.times = new Dictionary<string, TimeSpan>();
        this.beat = new Dictionary<string, bool>();
        this.CRTActive = true;
        this.sprite = new Tuple<Sprite, RuntimeAnimatorController>(sprite2, anim);
    }
}
