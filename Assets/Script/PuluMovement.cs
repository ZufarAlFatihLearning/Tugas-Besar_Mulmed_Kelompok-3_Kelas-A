using UnityEngine;

public class PuluMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed = 3f;
    [SerializeField] private int startDirection = 1;
    [SerializeField] private bool stayOnLedges = true; // Anda menambahkan ini, bagus!
    private int currentDirection;
    private float halfWidth;
    private float halfHeight;
    private Vector2 movement;
    private bool isGrounded;

    private void Start()
    {
        halfWidth = spriteRenderer.bounds.extents.x;
        halfHeight = spriteRenderer.bounds.extents.y;
        currentDirection = startDirection;
    }

    private void FixedUpdate()
    {
        // Pindahkan SetDirection() ke atas agar arah ditentukan sebelum bergerak
        SetDirection();
        
        movement.x = speed * currentDirection;
        movement.y = rigidBody.linearVelocity.y;
        rigidBody.linearVelocity = movement;
    }

    // PERBAIKAN 1: Nama fungsi diperbaiki dari 'OCollisionStay2D' menjadi 'OnCollisionStay2D'
    private void OnCollisionStay2D(Collision2D other)
    {
        // Pastikan objek yang bersentuhan memiliki Tag "Ground"
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void SetDirection()
    {
        // PERBAIKAN 2: Logika ini sekarang akan berjalan karena isGrounded bisa menjadi true
        if (!isGrounded) return;
        
        // --- Mulai dari sini, kodenya kembali ke versi yang sudah kita perbaiki sebelumnya ---
        // Karena logika raycast untuk jurang Anda sebelumnya masih kurang tepat

        Vector2 rightPos = new Vector2(transform.position.x + halfWidth, transform.position.y - halfHeight);
        Vector2 leftPos = new Vector2(transform.position.x - halfWidth, transform.position.y - halfHeight);

        if (rigidBody.linearVelocity.x > 0) // Bergerak ke Kanan
        {
            // Cek Dinding
            if (Physics2D.Raycast(transform.position, Vector2.right, halfWidth + 0.1f, LayerMask.GetMask("Ground")))
            {
                currentDirection *= -1;
                spriteRenderer.flipX = true;
            }
            // Cek Jurang
            else if (stayOnLedges && !Physics2D.Raycast(rightPos, Vector2.down, 0.2f, LayerMask.GetMask("Ground")))
            {
                currentDirection *= -1;
                spriteRenderer.flipX = true;
            }
        }
        else if (rigidBody.linearVelocity.x < 0) // Bergerak ke Kiri
        {
            // Cek Dinding
            if (Physics2D.Raycast(transform.position, Vector2.left, halfWidth + 0.1f, LayerMask.GetMask("Ground")))
            {
                currentDirection *= -1;
                spriteRenderer.flipX = false;
            }
            // Cek Jurang
            else if (stayOnLedges && !Physics2D.Raycast(leftPos, Vector2.down, 0.2f, LayerMask.GetMask("Ground")))
            {
                currentDirection *= -1;
                spriteRenderer.flipX = false;
            }
        }
    }
}