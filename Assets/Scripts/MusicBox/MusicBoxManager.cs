using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(FillVisualizer))]
public class MusicBoxManager : MonoBehaviour
{
    [SerializeField] private float _timeBeforeDecrease;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float _decreaseRate;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float _increaseRate;

    [SerializeField] private ColorData _color;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        _startDecreaseTime = Time.time;
        _volume = audioSource.volume;
    }

    private void Start()
    {
        GetComponent<FillVisualizer>().SetMaterial(_color.material);
    }

    private void Update()
    {
        if(Time.time > _startDecreaseTime)
        {
            AddVolume(-_decreaseRate * Time.deltaTime);
        }
    }

    private void AddVolume(float amount)
    {
        _volume += amount;
        _volume = Mathf.Clamp01(_volume);
        audioSource.volume = _volume;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Particle"))
        {

            string otherColor = collider.GetComponent<ParticleColor>().Color.title;

            if(_color.title.Equals(otherColor))
            {
                AddVolume(_increaseRate);
                _startDecreaseTime = Time.time + _timeBeforeDecrease;
            }
        }
    }

    private AudioSource audioSource;
    private float _volume;

    private float _startDecreaseTime;
}
