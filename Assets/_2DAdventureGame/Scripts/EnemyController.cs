
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float moveSpeed = 3f;

    ////////////////////////////////
    [SerializeField, Range(1, 5)] private int amountDamage = 2;
    ////////////////////////////////
    ///////////////////////////////////
    ///////////////////////////////////
    [SerializeField] bool verticalMovement;
    Rigidbody2D rigidBody2d;

    [SerializeField, Range(0.0f, 10.0f)] private float changeTime = 3.0f;
    float timer;
    int direction = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        ////////////////////////////////
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        ////////////////////////////////
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidBody2d.position;

        // If verticalMovement is true, move the enemy vertically; otherwise, move it horizontally.
        if (verticalMovement) position.y = position.y + moveSpeed * Time.deltaTime * direction;
        else position.x = position.x + moveSpeed * Time.deltaTime * direction;
        ////////////////////////////////
        ///////////////////////////////////

        rigidBody2d.MovePosition(position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health targetHealth = other.GetComponent<Health>();
        ////////////////////////////////////////////////////////////////
        ///////////////////////////////////
        ///////////////////////////////////

        if (targetHealth != null) targetHealth.ChangeHealth(-amountDamage);
        ////////////////////////////////
        ///////////////////////////////////
    }
    ////////////////////////////////////////////////////////////////
    ///////////////////////////////////
    ///////////////////////////////////

}