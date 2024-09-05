using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpriteController : MonoBehaviour, IDataPersistence
{
    private GameObject player;
    
    public static SpriteController instance;
    
    private Tuple<Sprite, RuntimeAnimatorController> playerSprite;
    
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private RuntimeAnimatorController defaultAnim;
    
    void Awake() 
    {
        if (instance == null) 
        {
            instance = this;
        }
        
        player = this.gameObject;
    }
    
    public void SaveData(ref GameData data) 
    {
        data.sprite = playerSprite;
    }
    
    public void LoadData(GameData data) 
    {
        playerSprite = data.sprite;
        if (playerSprite.Item1 == null) 
        {
            playerSprite = Tuple.Create(defaultSprite, defaultAnim);   
        }
        replaceSprite(playerSprite.Item1, playerSprite.Item2);
    }
    
    public void replaceSprite(Sprite sprite, RuntimeAnimatorController anim) 
    {
        SpriteRenderer render = player.GetComponent<SpriteRenderer>();
        render.sprite = sprite;
        Animator _anim = player.GetComponent<Animator>();
        _anim.runtimeAnimatorController = anim;
        playerSprite = Tuple.Create(sprite, anim);
    }
}
