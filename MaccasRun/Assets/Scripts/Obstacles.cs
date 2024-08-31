using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Obstacles : MonoBehaviour
{
    private GameObject playerCollider;
    [SerializeField] private GameObject UI;
    [SerializeField] private AudioClip death;
    [SerializeField] private AudioMixerGroup _mixer;

    void Start()
    {
        // Get the CapsuleCollider2D component attached to the Player GameObject
        playerCollider = this.gameObject.transform.Find("Colliders").gameObject;
    }

    // This method is called when another Collider2D enters the trigger zone of this GameObject.
    void OnTriggerEnter2D(Collider2D target)
    {
        // Check if the entering GameObject has the "Deadly" tag

        if (target.gameObject.CompareTag("Deadly")){
            Time.timeScale = 0f;
            UI.SetActive(true);
            stopWatch.instance.stopTimer();
            SoundFXManager.instance.PlaySoundFXClip(death, this.transform, _mixer, 1f, 1f);
        }
    }

    // This method is called when a collision with another Collider2D occurs.
    void OnCollisionEnter2D(Collision2D target)
    {
        // Check if the colliding GameObject has the "Deadly" tag
        if (target.gameObject.CompareTag("Deadly")){
            Time.timeScale = 0f;
            UI.SetActive(true);
            stopWatch.instance.stopTimer();
            SoundFXManager.instance.PlaySoundFXClip(death, this.transform, _mixer, 1f, 1f);
        }
    }
}