using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VictimGrabHandler : MonoBehaviour
{
    public Transform chestPosition; // Reference to the chest position transform (empty GameObject or chest bone)
    private XRGrabInteractable grabInteractable;
    private InputDevice leftControllerDevice; // Input device for the left controller
    private InputDevice rightControllerDevice; // Input device for the right controller
    private bool isHoldingBothGrabButtons = false;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        // Get the devices for the controllers (left and right)
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Left, devices);
        if (devices.Count > 0)
        {
            leftControllerDevice = devices[0];
        }

        devices.Clear();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Right, devices);
        if (devices.Count > 0)
        {
            rightControllerDevice = devices[0];
        }
    }

    private void Update()
    {
        // Check if the grip buttons are pressed on both controllers
        bool leftGrabPressed = leftControllerDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool leftPressed) && leftPressed;
        bool rightGrabPressed = rightControllerDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool rightPressed) && rightPressed;

        // If both grab buttons are pressed, move the object to the chest and disable the grab interactable
        if (leftGrabPressed && rightGrabPressed && !isHoldingBothGrabButtons)
        {
            isHoldingBothGrabButtons = true;
            // Move the object to the chest position
            transform.position = chestPosition.position;
            transform.rotation = chestPosition.rotation;

            // Disable the grab interactable so it doesn't follow the hand anymore
            grabInteractable.enabled = false;
        }
        // If either button is released, reset the object and enable the grab interactable again
        else if ((!leftGrabPressed || !rightGrabPressed) && isHoldingBothGrabButtons)
        {
            isHoldingBothGrabButtons = false;
            // Optionally, add some physics to make it fall (e.g., Rigidbody if necessary)
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb)
            {
                rb.isKinematic = false; // Ensure it's not kinematic and falls
            }

            // Reset object and enable grabbing again
            grabInteractable.enabled = true;
        }
    }
}