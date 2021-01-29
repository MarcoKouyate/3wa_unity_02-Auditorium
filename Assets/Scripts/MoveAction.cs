using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour, IMouseDragAction
{
    [SerializeField] private GameObject _target;

    public void Awake()
    {
        _isSelected = false;
        _offset = Vector2.zero;
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            OnMouseDragEnd();
        }
    }

    public void UpdateMousePosition(RaycastHit2D hit)
    {
        _hit = hit;

        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDragBegin();
        }

        if (_isSelected)
        {
            Vector2 newPosition = _hit.point + _offset;
            _target.transform.position = new Vector3(newPosition.x, newPosition.y, _target.transform.position.z);
        }
    }


    public void OnMouseDragBegin()
    {
        _isSelected = true;
        _offset = (Vector2) transform.position - _hit.point;
    }

    public void OnMouseDragEnd()
    {
        _isSelected = false;
    }

    private RaycastHit2D _hit;
    private bool _isSelected;
    private Vector2 _offset;
}
