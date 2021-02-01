using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelWinTransition))]
public class LevelManager : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] float _winVolume;
    [SerializeField] float _winDuration;

    private void Awake()
    {
        _winTransition = GetComponent<LevelWinTransition>();
        GameObject[] musicBoxes = GameObject.FindGameObjectsWithTag("MusicBox");
        _audioSources = RetrieveAudioSources(musicBoxes);
    }

    private AudioSource[] RetrieveAudioSources(GameObject[] gameObjects)
    {
        AudioSource[] audioSources = new AudioSource[gameObjects.Length];

        for (int i = 0; i < gameObjects.Length; i++)
        {
            audioSources[i] = gameObjects[i].GetComponent<AudioSource>();
        }
        return audioSources;
    }

    private void Update()
    {
        if (AreAudioFullVolume())
        {
            if (Time.time > _winTime)
            {
                _winTransition.Win();
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

    private LevelWinTransition _winTransition;
    private AudioSource[] _audioSources;
    private float _winTime;
}
