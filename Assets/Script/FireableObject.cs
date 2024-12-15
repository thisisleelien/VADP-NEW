using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireableObject : MonoBehaviour
{
    public ExtinguishFire extinguishFire;

    [Header("Particle Effect")]
    public ParticleSystem FireParticleEffect;
    public AudioSource fireSoundEffect;

    [Header("Object Stat")]
    public bool startFire;
    private bool endFire;

    [SerializeField] private bool isExtinguish;
    private Coroutine fireCoroutine;

    private void Start()
    {
        // Automatically find the "Extinguish effect" GameObject and set the reference
        GameObject extinguishEffectObject = GameObject.Find("Extinguish Effect");
        if (extinguishEffectObject != null)
        {
            extinguishFire = extinguishEffectObject.GetComponent<ExtinguishFire>();
            if (extinguishFire == null)
            {
                Debug.LogError("ExtinguishFire component is missing on 'Extinguish effect' GameObject.");
            }
        }
        else
        {
            Debug.LogError("GameObject named 'Extinguish effect' not found in the scene.");
        }

        // Initialize fire sound effect and start fire if required
        fireSoundEffect = GetComponent<AudioSource>();
        if (startFire)
        {
            StartFireObject();
        }
    }

    private void Update()
    {
        if (extinguishFire != null)
        {
            endFire = extinguishFire.isExtinguish;
        }
        else
        {
            Debug.LogWarning("ExtinguishFire reference is not set.");
        }
    }

    public void StartFireObject()
    {
        if (FireParticleEffect != null && !FireParticleEffect.isPlaying)
        {
            FireParticleEffect.Play();
            if (fireSoundEffect != null)
            {
                fireSoundEffect.Play();
            }
        }
    }

    private void EndFireObject()
    {
        if (fireSoundEffect != null && endFire)
        {
            fireSoundEffect.Stop();
        }
    }
}
