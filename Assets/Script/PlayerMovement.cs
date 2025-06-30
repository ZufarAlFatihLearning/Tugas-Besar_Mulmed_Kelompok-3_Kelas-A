using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    AudioManager audioManager;

    //gerak
    [SerializeField] private float speed = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    public float wallJumpCooldown { get; set; }
    private Vector2 movement;
    private Vector2 screenBounds;
    private float PlayerHalfWidth;
    private float xPosLastFrame;

    public TextMeshProUGUI WINTEXT;

    public GameOverScreen GameOverScreen;
    int maxPlatform = 0;

    //nyawa
    public int nyawa = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        PlayerHalfWidth = spriteRenderer.bounds.extents.x;

        
    }

    public void GameOver()
    {
        GameOverScreen.Setup();
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        //ClampMovement();
        FlipCharacterX();

        if (wallJumpCooldown > 0f)
        {
            wallJumpCooldown -= Time.deltaTime;
        }

        //nyawa
        if (nyawa <= 0)
        {
            GameOver();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Win")
        {
            WINTEXT.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void FlipCharacterX()
    {
        if (transform.position.x > xPosLastFrame)
        {
            //we are moving right
            spriteRenderer.flipX = false;
        }
        else if (transform.position.x < xPosLastFrame)
        {
            //we are moving left
            spriteRenderer.flipX = true;
        }

        xPosLastFrame = transform.position.x;
    }

    private void ClampMovement()
    {
        
    }

    private void HandleMovement()
    {
        if (wallJumpCooldown > 0f) return;

        float input = Input.GetAxis("Horizontal");
        movement.x = input * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
