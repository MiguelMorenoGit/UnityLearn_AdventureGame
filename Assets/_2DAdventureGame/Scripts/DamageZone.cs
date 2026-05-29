using UnityEngine;

public class DamageZone : MonoBehaviour

{
    [SerializeField, Min(1)] private int damageAmount = 1;
    private void OnTriggerStay2D(Collider2D collider)
    {
        Health targetHealth = collider.GetComponent<Health>();

        if (targetHealth != null && targetHealth.health > 0)
        {
            targetHealth.ChangeHealth(-damageAmount);
        }
    }
    
}
