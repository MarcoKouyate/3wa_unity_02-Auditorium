using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _particlePrefab;
    [SerializeField] private float _interval;
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;
    [SerializeField] private float _drag;

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
        particleRigidbody.drag = _drag;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _radius);
        DrawGizmoArrow(transform.position, transform.up * _speed * .1f, Color.cyan);
    }

    public static void DrawGizmoArrow(Vector3 origin, Vector3 direction, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
    {
        Gizmos.color = color;
        Gizmos.DrawRay(origin, direction);
        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(arrowHeadAngle, 0, 0) * Vector3.back;
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(-arrowHeadAngle, 0, 0) * Vector3.back;
        Gizmos.DrawRay(origin + direction, right * arrowHeadLength);
        Gizmos.DrawRay(origin + direction, left * arrowHeadLength);
    }

    private float _nextSpawnTime;
    private Transform _particlesFolderTransform;
}
