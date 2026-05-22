using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position = position + new Vector2(0.01f, 0.01f); // Move the player to the right at a constant speed
        transform.position = position;
    }
}
