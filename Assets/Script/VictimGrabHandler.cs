using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VictimGrabHandler : MonoBehaviour
{
    public GameObject chestVictim; // Cube in front of the chest to activate/deactivate
    public XRGrabInteractable grabInteractable;
    public MeshRenderer meshRenderer;

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

        if (meshRenderer != null)
        {
            // Disable the mesh renderer of the grabbed object
            meshRenderer.enabled = false;
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (chestVictim != null)
        {
            // Deactivate the chest cube
            chestVictim.SetActive(false);
        }

        if (meshRenderer != null)
        {
            // Enable the mesh renderer of the released object
            meshRenderer.enabled = true;
        }
    }
}
