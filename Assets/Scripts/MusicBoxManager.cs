using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicBoxManager : MonoBehaviour
{
    [SerializeField] float _timeBeforeDecrease;

    [Range(0.0f, 1.0f)]
    [SerializeField] float _decreaseRate;

    [Range(0.0f, 1.0f)]
    [SerializeField] float _increaseRate;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _startDecreaseTime = Time.time;
        _volume = audioSource.volume;
    }

    private void Update()
    {
        if(Time.time > _startDecreaseTime)
        {
            addVolume(-_decreaseRate * Time.deltaTime);
        }
    }

    private void addVolume(float amount)
    {
        _volume += amount;
        _volume = Mathf.Clamp01(_volume);
        audioSource.volume = _volume;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Particle"))
        {
            addVolume(_increaseRate);
            _startDecreaseTime = Time.time + _timeBeforeDecrease;
        }
    }

    private AudioSource audioSource;
    private float _volume;

    private float _startDecreaseTime;
}
