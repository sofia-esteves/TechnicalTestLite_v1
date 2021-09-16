﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    private AudioManager audioManager;
    public Slider ThemeSlider;
    public Slider SoundEffectsSlider;

    private void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        ThemeSlider.value = audioManager.Sounds.Where(s => s.Name == "BackgroundSound").FirstOrDefault().AudioSource.volume;
        SoundEffectsSlider.value = audioManager.Sounds.Where(s => s.Name == "ButtonSound").FirstOrDefault().AudioSource.volume;
    }
    public void SetThemeVolume(float value)
    {
        if (audioManager != null)
        {
            audioManager.Sounds.Where(s => s.Name == "BackgroundSound").FirstOrDefault().AudioSource.volume = value;
        }
    }

    public void SetSoundEffectsVolume(float value)
    {
        if (audioManager != null)
        {
            foreach(var sound in audioManager.Sounds)
            {
                if(sound.Name!= "BackgroundSound")
                {
                    sound.AudioSource.volume = value;
                }
            };
        }
    }
}
