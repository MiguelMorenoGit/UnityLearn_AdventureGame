using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction; // Input action for moving

    [SerializeField, Range(0f, 0.1f)]
    public float moveSpeed = 0.05f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = MoveAction.ReadValue<Vector2>(); // Read the movement input
        Debug.Log(move);

        // Calculate the new position based on input and move speed
        Vector2 position = (Vector2)transform.position + move * moveSpeed;

        transform.position = position; // Move the player based on input

    }
}
