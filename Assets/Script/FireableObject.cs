using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireableObject : MonoBehaviour
{
    [Header("Particle Effect")] 
    public ParticleSystem FireParticleEffect;
    
    [Header("Object Stat")]
    public bool startFire;
    
    [SerializeField] private bool isExtinguish;
    private Coroutine fireCoroutine;
    
    private void Start()
    {
        if (startFire)
        {
            StartFireObject();
        }
    }

    public void StartFireObject()
    {
        if (FireParticleEffect != null && !FireParticleEffect.isPlaying)
        {
            FireParticleEffect.Play();
        }
    }
}
