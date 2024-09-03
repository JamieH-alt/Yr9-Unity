using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class Collectables : MonoBehaviour, IDataPersistence
{
    [SerializeField] private TMP_Text collected;

    [SerializeField] private AudioClip _coinClip;
    [SerializeField] private AudioMixerGroup _FX;

    public static Collectables instance;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void LoadData(GameData data)
    {
        int collectedAm = data.fries;
        collected.GetComponent<TMP_Text>().SetText(collectedAm.ToString());
    }

    public void SaveData(ref GameData data)
    {
        data.fries = GetCollected();
    }

    public int GetCollected()
    {
        int collectedAm = int.Parse(collected.GetComponent<TMP_Text>().text);
        return collectedAm;
    }

    // This method is called when another Collider2D enters the trigger zone of this GameObject.
    void OnTriggerEnter2D(Collider2D target)
    {
        // Check if the entering GameObject has the "Deadly" tag
        if (target.gameObject.CompareTag("Collectable")){
            SoundFXManager.instance.PlaySoundFXClip(_coinClip, target.gameObject.transform, _FX, 0.6f, 1);
            Destroy(target.gameObject);
            int collectedAm = int.Parse(collected.GetComponent<TMP_Text>().text) + 1;
            collected.GetComponent<TMP_Text>().SetText(collectedAm.ToString());
        }
    }

    // This method is called when a collision with another Collider2D occurs.
    // void OnCollisionEnter2D(Collision2D target)
    // {
        // Check if the colliding GameObject has the "Deadly" tag
        // if (target.gameObject.CompareTag("Collectable")){
            // int collectedAm = int.Parse(collected.GetComponent<TMP_Text>().text) + 1;
            // collected.GetComponent<TMP_Text>().SetText(collectedAm.ToString());
            // Destroy(target.gameObject);
        // }
    // }
}
