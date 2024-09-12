// Player sounds


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip crashSound, hitSound, deathSound, shootSound;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int i = 0) {
        switch (i) {
            case (1): 
                audioSource.PlayOneShot(hitSound, 1);
            break;

            
            case (2): 
                audioSource.PlayOneShot(deathSound, 1);
            break;

            
            case (3): 
                audioSource.PlayOneShot(shootSound, 1);
            break;

            default: break;
        }
    }



    private void OnCollisionEnter2D(Collision2D other) {
        audioSource.PlayOneShot(crashSound, 1);
    }
}
