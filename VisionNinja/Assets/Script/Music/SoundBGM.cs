using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBGM : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioClip1;
    public static bool isMusicS;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        bool isMusic = OptionCtrl.isMusic;
        if (isMusic && !isMusicS)
        {
            audioSource.Play();
            isMusicS = true;
        }
        if(!isMusic)
        {
            audioSource.Stop();
        }
    }
}
