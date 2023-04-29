using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound()
    {
        int x = (int)Random.Range(1f, 4f);
        switch (x)
        {
            
            case 1: audioSource1.Play();
                break;
            case 2: audioSource2.Play();
                break;
            case 3: audioSource3.Play();
                break;
        }
        PlaySound();
    }
}
