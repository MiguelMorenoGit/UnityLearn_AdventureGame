using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth = 5;
    int currentHealth;


    
    void Start()
    {
        //currentHealth = maxHealth;
        currentHealth = 1;
    }

    
    void Update()
    {
        
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
