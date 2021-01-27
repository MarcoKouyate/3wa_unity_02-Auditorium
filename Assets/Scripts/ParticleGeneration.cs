using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _particlePrefab;
    [SerializeField] private float _interval;
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;

    private void Awake()
    {
        _nextSpawnTime = Time.time;
        _particlesFolderTransform = GameObject.Find("Particles").transform;
    }

    private void Update()
    {
        if(Time.time > _nextSpawnTime){
            SpawnParticle();
            _nextSpawnTime = Time.time + _interval;
        }
    }

    private void SpawnParticle()
    {
        //Spawn a particle at a random position around object
        Vector2 randomPositionInsideCircle = Random.insideUnitCircle * _radius;
        Vector2 particlePosition = (Vector2) transform.position + randomPositionInsideCircle;
        GameObject particle = Instantiate(_particlePrefab, particlePosition, transform.rotation, _particlesFolderTransform);

        // Initialize particle movement
        Rigidbody2D particleRigidbody = particle.GetComponent<Rigidbody2D>();
        particleRigidbody.velocity = transform.up * _speed;
    }

    private float _nextSpawnTime;
    private Transform _particlesFolderTransform;
}
