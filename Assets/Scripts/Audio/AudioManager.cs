using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Audio Manager keeps an array of sounds and method Play Sound.
    /// Manages the Audio Manager instance.
    /// Class is not destroyed when going to a different scene.
    /// </summary>
    public Sound[] Sounds;
    public static AudioManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in Sounds)
        {
            s.AudioSource = gameObject.AddComponent<AudioSource>();
            s.AudioSource.clip = s.Clip;
            s.AudioSource.volume = s.Volume;
            s.AudioSource.pitch = s.Pitch;
            s.AudioSource.loop = s.Loop;
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
