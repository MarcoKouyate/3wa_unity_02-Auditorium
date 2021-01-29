using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] float _winVolume;
    [SerializeField] float _winDuration;

    private void Awake()
    {
        GameObject[] musicBoxes = GameObject.FindGameObjectsWithTag("MusicBox");
        _audioSources = new AudioSource[musicBoxes.Length];

        for(int i = 0; i < musicBoxes.Length; i++)
        {
            _audioSources[i] = musicBoxes[i].GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (AreAudioFullVolume())
        {
            if (Time.time > _winTime)
            {
                Win();
            }
        } else
        {
            _winTime = Time.time + _winDuration;
        }
    }


    private bool AreAudioFullVolume()
    {
        bool isCompleted = true;

        foreach(AudioSource audioSource in _audioSources)
        {
            isCompleted = isCompleted && IsAudioFullVolume(audioSource);
        }

       return isCompleted;
    }

    private bool IsAudioFullVolume(AudioSource audioSource)
    {
        return audioSource.volume >= _winVolume;
    }

    private void Win()
    {
        Debug.Log("WIN");
    }

    private AudioSource[] _audioSources;
    private float _winTime;
}
