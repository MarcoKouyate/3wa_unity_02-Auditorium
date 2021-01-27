using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private void Awake()
    {
        PlayAllMusicBoxesAtSameTime();
    }

    private void PlayAllMusicBoxesAtSameTime()
    {
        GameObject[] musicBoxes = GameObject.FindGameObjectsWithTag("MusicBox");

        foreach (GameObject musicBox in musicBoxes)
        {
            AudioSource audioSource = musicBox.GetComponent<AudioSource>();

            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
