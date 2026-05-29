using UnityEngine;

public class Health : MonoBehaviour
{
    //Variables related to health
    public int maxHealth = 5;
    int currentHealth;
    public int health { get { return currentHealth; } }

    //Variables
    [SerializeField, Range(0.0f,5.0f)] 
    private float timeInvincible = 2.0f;
    private bool isInvincible;
    private float damageCooldown;


    void Start()
    {
        currentHealth = maxHealth;
        
    }

    
    void Update()
    {
        if (isInvincible)
        {
            // If we are invincible, we need to count down the cooldown timer,
            damageCooldown -= Time.deltaTime;
            if(damageCooldown <= 0)
            {
                isInvincible = false;
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        // If the amount is negative, we are taking damage,
        // so we need to check if we are invincible or not.
        // If we are invincible, we don't take damage,
        // but if we are not invincible, we take damage and become invincible for a short time.
        if (amount < 0)
        {
            if (isInvincible) return;
            else
            {
                isInvincible = true;
                damageCooldown = timeInvincible;
            }
        }

        // If we are invincible, we need to count down the cooldown timer,
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
