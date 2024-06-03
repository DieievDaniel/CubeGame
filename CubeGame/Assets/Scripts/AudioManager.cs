using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip coinPickupSound;

    private AudioSource audioSource;
    #region MONO
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Play background music
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.Play();
        }
    }

    #endregion
    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void ResumeMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void PlayCoinPickupSound()
    {
        audioSource.PlayOneShot(coinPickupSound);
    }
}
