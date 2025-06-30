using UnityEngine;

public class Duri : MonoBehaviour
{
    PlayerMovement KomoponenGerak;

    AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        KomoponenGerak = GameObject.Find("Kodok").GetComponent<PlayerMovement>();
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            KomoponenGerak.nyawa--;
        }

        if (audioManager != null)
        {
            audioManager.MuteMusic(true);
            audioManager.PlaySFX(audioManager.death);
        }
    }
}
