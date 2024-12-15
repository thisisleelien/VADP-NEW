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
         // Update state
        //Debug.Log("Extinguisher unlocked!");

        // Optional: Animate or move the pin to simulate removal
        if (extinguisherPin != null)
        {
            extinguisherPin.gameObject.SetActive(false); // Hide pin
            // Alternatively, use an animation or position adjustment:
            // extinguisherPin.localPosition += new Vector3(0, 0.1f, 0);
            isUnlocked = true;
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
