using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VictimGrabHandler : MonoBehaviour
{
    public GameObject chestVictim; // Cube in front of the chest to activate/deactivate
    public XRGrabInteractable grabInteractable;
    public SkinnedMeshRenderer[] skinnedMeshRenderers; // Array for multiple SkinnedMeshRenderers

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (chestVictim != null)
        {
            // Activate the chest cube
            chestVictim.SetActive(true);
        }

        // Disable all SkinnedMeshRenderers
        foreach (var renderer in skinnedMeshRenderers)
        {
            renderer.enabled = false;
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (chestVictim != null)
        {
            transform.position = chestVictim.transform.position;
            transform.rotation = chestVictim.transform.rotation;

            // Deactivate the chest cube
            chestVictim.SetActive(false);
        }

        // Enable all SkinnedMeshRenderers
        foreach (var renderer in skinnedMeshRenderers)
        {
            renderer.enabled = true;
        }
    }
}
