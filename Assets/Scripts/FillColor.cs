using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class FillColor : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float amount;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
        _originalColor = _material.color;
    }

    private void Update()
    {
        _material.color = new Color(_originalColor.r, _originalColor.g, _originalColor.b,  amount);
    }

    private Material _material;
    private Color _originalColor;
}
