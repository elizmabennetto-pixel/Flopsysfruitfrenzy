using UnityEngine;
using System;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource backgroundMusicSource;
    public AudioSource soundEffectSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusicClip;
    public AudioClip[] soundEffectClips;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic() {
        backgroundMusicSource.clip = backgroundMusicClip;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlaySoundEffect(int clipIndex) {
        if (clipIndex < soundEffectClips.Length) {
            soundEffectSource.clip = soundEffectClips[clipIndex];
            soundEffectSource.Play();
        } else {
            Debug.LogWarning("Sound effect index out of range!");
        }
    }
}