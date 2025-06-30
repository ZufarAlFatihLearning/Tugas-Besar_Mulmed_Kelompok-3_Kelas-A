using UnityEngine;

public class AudioManagerMainMenu : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    

    [Header("---------- Audio Clip ----------")]
    public AudioClip backgroundmainmenu;
    
    

    private void Start()
    {
        musicSource.clip = backgroundmainmenu;
        musicSource.Play();
    }

   
}
