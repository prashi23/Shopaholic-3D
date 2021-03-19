using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance { get; private set; }
    private AudioSource audioSource;
    void Awake() {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPickSound() {
        audioSource.Play();
    }


}
