using UnityEngine;

public class SafeZoneSystem : MonoBehaviour
{
    public ScoreManager scoreManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Civilians"))
        {
            scoreManager.AddCivilians();
            Destroy(other.gameObject);
        }
    }
}
