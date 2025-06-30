using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.Tilemaps;
using UnityEngine;
using UnityEngine.Splines;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed = 3f;
    [SerializeField] private int startDirection = 1;
    private int currentDirection;
    private float halfWidth;
    private Vector2 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        halfWidth = spriteRenderer.bounds.extents.x;
        currentDirection = startDirection;
        spriteRenderer.flipX = startDirection == 1 ? false : true;
    }


    private void FixedUpdate()
    {

        movement.x = speed * currentDirection;
        movement.y = rigidBody.linearVelocity.y;
        rigidBody.linearVelocity = movement;
        SetDirection();
    }

    private void SetDirection()
    {
        // Visualisasikan Raycast ke kanan (berwarna hijau)
        Debug.DrawRay(transform.position, Vector2.right * (halfWidth + 0.1f), Color.green);

        // Visualisasikan Raycast ke kiri (berwarna merah)
        Debug.DrawRay(transform.position, Vector2.left * (halfWidth + 0.1f), Color.red);

        if (Physics2D.Raycast(transform.position, Vector2.right, halfWidth + 0.1f, LayerMask.GetMask("Ground")) &&
        rigidBody.linearVelocity.x > 0)
        {
            currentDirection *= -1;
            spriteRenderer.flipX = true;
        }
        else if (Physics2D.Raycast(transform.position, Vector2.left, halfWidth + 0.1f, LayerMask.GetMask("Ground")) &&
        rigidBody.linearVelocity.x < 0)
        {
            currentDirection *= -1;
            spriteRenderer.flipX = false;
        }
    }
}
