using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(TrailRenderer))]
public class ParticleColor : MonoBehaviour
{
    [SerializeField] private ColorData _currentColor;

    public ColorData Color
    {
        get => _currentColor;
    }

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _trailRenderer = GetComponent<TrailRenderer>();

        SetColor(_currentColor);
    }

    public void SetColor(ColorData newColor)
    {
        _meshRenderer.material = newColor.material;
        _trailRenderer.material = newColor.material;
        _currentColor = newColor;
    }

    private MeshRenderer _meshRenderer;
    private TrailRenderer _trailRenderer;
}
