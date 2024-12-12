using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExtinguishFire : MonoBehaviour
{
    public ParticleSystem extinguisherEffect;
    public InputActionReference triggerAction;
    public ScoreManager scoreManager;
    
    
    private void OnEnable()
    {
        triggerAction.action.Enable();
    }

    private void OnDisable()
    {
        triggerAction.action.Disable();
    }
    
    private void Update()
    {
        if (triggerAction.action.IsPressed())
        {
            if (!extinguisherEffect.isPlaying)
            {
                extinguisherEffect.Play();
            }
        }
        else
        {
            if (extinguisherEffect.isPlaying)
            {
                extinguisherEffect.Stop();
            }
        }
    }
    
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("fire"))
        {
            other.GetComponent<ParticleSystem>().Stop();
            other.transform.GetChild(2).gameObject.SetActive(true);
            scoreManager.AddFireExtinguish();
        }
    }
}
