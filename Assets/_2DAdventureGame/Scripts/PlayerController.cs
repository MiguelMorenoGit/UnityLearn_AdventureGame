using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction; // Input action for moving
    Rigidbody2D rigidBody2d;
    Vector2 move;
    //public int frameRate = 60; // Desired frame rate for the game

    [SerializeField, Range(0f, 10f)] private float moveSpeed = 3f;
    [SerializeField, Range(0f, 0.3f)] private float rightMotorSpeed = 0.1f;
    [SerializeField, Range(0f, 0.3f)] private float leftMotorSpeed = 0.1f;


    // Start is called before the first frame update

    private void Start()
    {
        //QualitySettings.vSyncCount = 0;

        //Application.targetFrameRate = frameRate;
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    // This method is called when the object becomes enabled and active
    private void OnEnable()
    {
        MoveAction.Enable();
        MoveAction.performed += OnMove;
        MoveAction.canceled += OnMove;
    }

    // This method is called when the object becomes disabled or inactive
    private void OnDisable()
    {
        MoveAction.performed -= OnMove;
        MoveAction.canceled -= OnMove;
        MoveAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>(); // Read the movement input
        Debug.Log(move);

    }

    private void FixedUpdate()
    {
        // Calculate the new position based on the current position, movement input, and move speed
        Vector2 position = (Vector2)rigidBody2d.position + move * moveSpeed * Time.deltaTime;

        rigidBody2d.MovePosition(position); // Move the player based on input
    }

    // This method is called when the MoveAction is performed or canceled
    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 move = MoveAction.ReadValue<Vector2>(); // Read the movement input
        Debug.Log($"Control usado: {context.control.path}");
        Debug.Log($"Dispositivo: {context.control.device.displayName}");

        bool isLeftStick = context.control.path.Contains("leftStick");

        // Trigger rumble if the input is from the left stick and there is movement
        if (move != Vector2.zero && isLeftStick) rumbleToGamepad();
    }

    private void rumbleToGamepad()
    {
        if (Gamepad.current != null)
        {

            Gamepad.current.SetMotorSpeeds(leftMotorSpeed, rightMotorSpeed); // Set rumble intensity (left and right motors)
            Invoke("StopRumble", 0.1f); // Stop rumble after 0.5 seconds

        } 
    }

    private void StopRumble()
    {
        if (Gamepad.current != null)
        {
            Gamepad.current.ResetHaptics(); // Stop rumble
        }
    }
}
