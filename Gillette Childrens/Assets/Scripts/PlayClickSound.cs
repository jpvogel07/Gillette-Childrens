using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class PlayClickSound : MonoBehaviour
{
    private AudioSource aSource;
    private void Start() {
        aSource = GetComponent<AudioSource>();
    }
    private void Awake()
    {
        PlayerMovement.playClick += playSound;
    }
    private void onDisable()
    {
        PlayerMovement.playClick -= playSound;
    }

    private void playSound()
    {
        //Debug.Log("Recieved");
        if(aSource)
            aSource.Play(0);
    }
}
