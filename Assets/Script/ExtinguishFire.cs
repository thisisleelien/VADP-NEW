using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExtinguishFire : MonoBehaviour
{
    public ParticleSystem extinguisherEffect; // Spray particle system
    public InputActionReference triggerAction; // Trigger input (spray action)
    public InputActionReference unlockAction; // A button input (unlock action)
    public Transform extinguisherPin; // Reference to the pin object
    public Animator Animation;
    public ScoreManager scoreManager;

    private bool isUnlocked = false; // State for unlocking

    private void OnEnable()
    {
        triggerAction.action.Enable();
        unlockAction.action.Enable();
    }

    private void OnDisable()
    {
        triggerAction.action.Disable();
        unlockAction.action.Disable();
    }

    private void Update()
    {
        // Check if the A button is pressed to unlock
        if (unlockAction.action.IsPressed() && !isUnlocked)
        {
            UnlockExtinguisher();
        }

        // Check if the trigger button is pressed for spraying
        if (triggerAction.action.IsPressed())
        {
            if (isUnlocked && !extinguisherEffect.isPlaying)
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

    private void UnlockExtinguisher()
    {
        if (extinguisherPin != null)
        {
            Animation.SetBool("isPull", true);
            Invoke(nameof(HideExtinguisherPin), 1f); // Call HideExtinguisherPin after 1 second
            isUnlocked = true;
        }
    }

    private void HideExtinguisherPin()
    {
        extinguisherPin.gameObject.SetActive(false); // Hide pin
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
