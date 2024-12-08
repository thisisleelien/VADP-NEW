using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireableObject : MonoBehaviour
{
    [Header("Particle Effect")] 
    public ParticleSystem FireParticleEffect;
    
    [Header("Object Stat")]
    public int Health = 100;
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

        // Start decreasing health
        if (fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(DecreaseHealthOverTime());
        }
    }
    
    private IEnumerator DecreaseHealthOverTime()
    {
        while (Health > 0 && !isExtinguish)
        {
            Health -= 1; 
            yield return new WaitForSeconds(0.5f);
        }

        if (Health <= 0)
        {
            DestroyObject();
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
