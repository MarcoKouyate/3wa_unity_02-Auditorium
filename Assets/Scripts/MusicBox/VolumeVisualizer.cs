using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(FillVisualizer))]
public class VolumeVisualizer : MonoBehaviour
{

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        visualizer = GetComponent<FillVisualizer>();
    }

    private void Update()
    {
        visualizer.Fill(audioSource.volume);
    }

    private AudioSource audioSource;
    private FillVisualizer visualizer;
}
