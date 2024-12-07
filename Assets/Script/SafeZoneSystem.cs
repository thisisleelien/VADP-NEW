using UnityEngine;

public class SafeZoneSystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Civilians"))
        {
            Debug.Log("Save Civilians");
            
        }
    }
}
