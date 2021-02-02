using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CursorSelector))]
public class MouseDragResize : MonoBehaviour, IMouseDragAction
{
    [SerializeField] float _minRadius;
    [SerializeField] float _maxRadius;

    public float MinRadius
    {
        get => _minRadius;
    }

    public float MaxRadius
    {
        get => _maxRadius;
    }

    public float Radius
    {
        get => _cursor.Radius;
    }


    private void Awake()
    {
        _isSelected = false;
        _cursor = GetComponent<CursorSelector>();
        _originalRadius = _cursor.Radius;
        _offset = 0;
    }


    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _isSelected = false;
        }
    }

    public void UpdateMousePosition(RaycastHit2D hit)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 direction = (Vector2)transform.position - _hit.point;
            _offset = direction.magnitude;
            _isSelected = true;
        }


        _hit = hit;
        if (_isSelected)
        {
            Vector2 direction = (Vector2)transform.position - hit.point;
            UpdateRadius(direction);
        }
    }


    private void UpdateRadius(Vector2 direction)
    {
        if (_minRadius * _minRadius < direction.sqrMagnitude)
        {
            float scale = _originalRadius *  _offset + _originalRadius *  (direction.magnitude - _offset);
            _cursor.Radius = Mathf.Clamp(scale, _minRadius, _maxRadius);
        }
    }


    private bool _isSelected;
    private float _originalRadius;
    private CursorSelector _cursor;
    private float _offset;
    private RaycastHit2D _hit;
}
