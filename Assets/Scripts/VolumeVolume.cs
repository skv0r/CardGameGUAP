using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeVolume : MonoBehaviour
{
    private AudioSource audioScr;
    private float musicVolume = 1f;
    void Start()
    {
        audioScr = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioScr.volume = musicVolume;
    }

    public void SetVolume (float vol) 
    {
        musicVolume = vol;
    }
}
