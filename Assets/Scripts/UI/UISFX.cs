using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISFX : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip click1, click2, hover;

    public delegate void AudioEvent(int val);
    public static AudioEvent playClick, playHover;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        playClick += PlayClick;
        playHover += PlayHover;
    }

    public void PlayClick(int i = 0) {
        if (i <= 0) audioSource.PlayOneShot(click1, 1);
        else audioSource.PlayOneShot(click2, 1);
    }

    public void PlayHover(int i = 0) {
        audioSource.PlayOneShot(hover, 1);
    }
}
