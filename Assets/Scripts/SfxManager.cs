using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    private AudioSource _source;

    public enum Effects
    {
        
    }
    
    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }
    
    public void MuteAll(bool mute = true)
    {
        _source.mute = mute;
    }
}
