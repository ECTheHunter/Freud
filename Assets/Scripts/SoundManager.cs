using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource audioSource;
    public AudioSource mainThemeSource;
    public AudioClip audioclip1;
    public AudioClip audioclip2;
    public AudioClip audioclip3;

    public bool PlayLevelSound = false;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (!PlayLevelSound) return;

        PlaySound();
    }

    public void PlayMainTheme()
    {
        mainThemeSource.time = 0;
        mainThemeSource.Play();
    }

    public void StopMainTheme()
    {
        mainThemeSource.Stop();
    }

    public void PlaySound()
    {
        if(audioSource.isPlaying == true)
        {
            return;
        }
        int x = Random.Range(1, 4);
        switch (x)
        {
            case 1: audioSource.clip = audioclip1;
                break;
            case 2: audioSource.clip = audioclip2;
                break;
            case 3: audioSource.clip = audioclip3;
                break;
        }
        audioSource.Play();
    }
}
