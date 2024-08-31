using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class HitStomp : MonoBehaviour
{

    [SerializeField] private GameObject _hitParticles;
    [SerializeField] private AudioClip _audio;
    [SerializeField] private AudioMixerGroup _FX;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            Destroy(other.transform.parent.gameObject);
            PlayerMovementV2.instance.InitiateJump(-1, _hitParticles);
            SoundFXManager.instance.PlaySoundFXClip(_audio, this.transform, _FX, 0.5f, 1f);
        }
    }
}