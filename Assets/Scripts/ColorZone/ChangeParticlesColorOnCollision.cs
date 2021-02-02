using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class ChangeParticlesColorOnCollision : MonoBehaviour
{
    [SerializeField] private ColorData _color;

    private void Awake()
    {
        GetComponent<LineRenderer>().material = _color.material;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Particle"))
        {
            other.GetComponent<ParticleColor>().SetColor(_color);
        }
    }
}
