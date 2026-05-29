using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healAmount = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Health otherHealth = other.GetComponent<Health>();

        if (otherHealth != null && otherHealth.health < otherHealth.maxHealth)
        {

            otherHealth.ChangeHealth(healAmount);
            Destroy(gameObject);
            
        }
    }
}
