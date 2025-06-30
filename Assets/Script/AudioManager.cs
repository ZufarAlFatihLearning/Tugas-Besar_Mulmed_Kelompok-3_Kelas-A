using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------- Audio Source -----------")]
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource sfxSource;

    [Header("----------- Audio Clip -----------")]
    public AudioClip backgroundMusic;
    public AudioClip death;
    public AudioClip jump;
    // ...klip lainnya

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    // --- FUNGSI BARU UNTUK MUTE ---
    // Fungsi ini menerima parameter boolean (true/false)
    // untuk menentukan apakah musik harus di-mute atau di-unmute.
    public void MuteMusic(bool isMuted)
    {
        musicSource.mute = isMuted;
    }
}