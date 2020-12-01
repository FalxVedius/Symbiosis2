﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

//Class for each individual Sound in the Audio Manager
[System.Serializable]
public class Sound
{
    //public Variables
    public AudioMixerGroup audioMixerGroup;
    public string clipName;
    public AudioClip clip;

    [Range(0.0f, 1.0f)]
    public float volume;

    [Range(0.0f, 2.0f)]
    public float pitch;

    [Range(0, 256)]
    public int priority;

    public bool loop = false;
    public bool playOnAwake = false;

    //private Variables
    private AudioSource source;

    //Sets the properties for the sound
    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.pitch = pitch;
        source.volume = volume;
        source.priority = priority;
        source.playOnAwake = playOnAwake;
        source.loop = loop;
        source.outputAudioMixerGroup = audioMixerGroup;
    }

    //Plays the sound
    public void Play()
    {
        source.Play();
    }

    //Stops the sound
    public void Stop()
    {
        source.Stop();
    }

    public void Pause()
    {
        source.Pause();
    }

    public void Resume()
    {
        source.UnPause();
    }
}

public class AudioManager : MonoBehaviour
{
    //public variables
    public static AudioManager instance;
    public AudioMixer audioMixer;

    //private variables
    float curMusicVol = 0.5f;
    float curSFXVol = 0.5f;

    //Array that holds each individual sound
    [SerializeField]
    Sound[] sounds;

    //Create Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound " + i + " " + sounds[i].clipName);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }
        DontDestroyOnLoad(gameObject);
    }


    //Creates an empty gameobject with AudioSource component for each sound in the Sounds Array and childs them under the Audio Manager
    private void Start()
    {

        DontDestroyOnLoad(gameObject);

    }

    //mixer setter
    public void SetMasterVolume(float masterVol)
    {

        audioMixer.SetFloat("MasterVolume", Mathf.Log10(masterVol) * 20);

    }

    public void SetMusicVolume(float musicVol)
    {

        audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVol) * 20);
        curMusicVol = musicVol;
    }

    public void SetSFXVolume(float sfxVol)
    {

        audioMixer.SetFloat("SFXVolume", Mathf.Log10(sfxVol) * 20);
        curSFXVol = sfxVol;

    }

    //mixer getter
    public float GetMasterVolume()
    {
        float masterVol;
        audioMixer.GetFloat("MasterVolume", out masterVol);
        return masterVol;
    }

    public float GetMusicVolume()
    {
        return curMusicVol;
    }

    public float GetSFXVolume()
    {
        return curSFXVol;
    }


    //When called, plays specified sound
    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].clipName == _name)
            {
                sounds[i].Play();
                return;
            }
        }

    }

    public void StopSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].clipName == _name)
            {
                sounds[i].Stop();
                return;
            }
        }
    }

    public void PauseSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].clipName == _name)
            {
                sounds[i].Pause();
                return;
            }
        }
    }

    public void ResumeSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].clipName == _name)
            {
                sounds[i].Resume();
                return;
            }
        }
    }
}
