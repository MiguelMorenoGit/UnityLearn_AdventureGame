using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healAmount = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Health playerHealth = other.GetComponent<Health>();

        if (playerHealth != null)
        {
            playerHealth.ChangeHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
