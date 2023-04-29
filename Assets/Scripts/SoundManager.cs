using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioclip1;
    public AudioClip audioclip2;
    public AudioClip audioclip3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaySound();
    }
    public void PlaySound()
    {
        if(audioSource.isPlaying == true)
        {
            return;
        }
        int x = (int)Random.Range(1f, 4f);
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
