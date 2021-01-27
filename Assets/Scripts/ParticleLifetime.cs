using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class ParticleLifetime : MonoBehaviour
{
    [SerializeField] private float _minimalSpeed;
    [SerializeField] private float _minimalLifetime;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _destroyTime = Time.time + _minimalLifetime;
    }

    private void FixedUpdate()
    {
        if(Time.time > _destroyTime && isSlowEnough())
        {
            Destroy(gameObject);
        }
    }

    private bool isSlowEnough()
    {
        return _rigidbody.velocity.sqrMagnitude < (_minimalSpeed * _minimalSpeed);
    }

    private Rigidbody2D _rigidbody;
    private float _destroyTime;
}
