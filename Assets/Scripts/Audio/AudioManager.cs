using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;
    private void Awake()
    {
        foreach(Sound s in Sounds)
        {
            s.AudioSource = gameObject.AddComponent<AudioSource>();
            s.AudioSource.clip = s.Clip;
            s.AudioSource.volume = s.Volume;
            s.AudioSource.pitch = s.Pitch;
        }
    }

    public void PlaySound(string name)
    {
       Sound s = Array.Find(Sounds, sound => sound.Name == name);
        if (s != null)
        {
            s.AudioSource.Play();
        }
    }
}
