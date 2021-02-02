using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MouseDragResize))]
[RequireComponent(typeof(AreaEffector2D))]
public class EffectorMagnitudeOverSize : MonoBehaviour
{
    [SerializeField] float _force;

    private void Start()
    {
        _areaEffector = GetComponent<AreaEffector2D>();
        _mouseDrag = GetComponent<MouseDragResize>();
    }

    private void Update()
    {
        _areaEffector.forceMagnitude = Mathf.Clamp(_mouseDrag.Radius, _mouseDrag.MinRadius, _mouseDrag.MaxRadius) * _force;
    }

    private AreaEffector2D _areaEffector;
    private MouseDragResize _mouseDrag;

}
