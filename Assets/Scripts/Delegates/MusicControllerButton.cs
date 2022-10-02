using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class MusicControllerButton : MonoBehaviour
{
    public Sprite onSprite;
    public Sprite offSprite;


    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ToggleMusic()
    {
        var current = AudioManager.Instance.IsMusicOn();

        current = !current;
        AudioManager.Instance.SetMusicOn(current);
        
        _image.sprite = current ? onSprite : offSprite;
    }

    public void ToggleSfx()
    {
        var current = AudioManager.Instance.IsSfxOn();
        
        current = !current;
        AudioManager.Instance.SetSfxOn(current);
        
        _image.sprite = current ? onSprite : offSprite;
    }
}
