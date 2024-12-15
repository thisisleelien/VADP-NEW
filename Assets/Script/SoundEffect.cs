using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource FireBell;

    private void Start()
    {
        FireBell = GetComponent<AudioSource>();
    }

    public void OnTutorialEndPressed()
    {
        FireBell.Play();
    }

    public void OnGameEnd()
    {
        FireBell.Stop();
    }
}
