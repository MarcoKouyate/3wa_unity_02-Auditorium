using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMouseDragAction))]
[RequireComponent(typeof(LineRenderer))]
public class CursorSelector : MonoBehaviour
{
    [SerializeField] private Texture2D icon;
    [SerializeField] private CircleShape circle;
    [SerializeField] private float _radius;
    [SerializeField] private Material _onMaterial;
    [SerializeField] private Material _offMaterial;

    private IMouseDragAction _action;

    #region Properties;
    public float Radius
    {
        get => _radius;
        set => _radius = value;
    }

    public Vector2 Hotspot
    {
        get => _hotspot;
    }

    #endregion

    #region Unity Cycle
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _hotspot = new Vector2(icon.width / 2, icon.height / 2);
        _wasInside = false;
        _action = GetComponent<IMouseDragAction>();
        _lineRenderer.material = _offMaterial;
    }

    public void Update()
    {
        CastRay();
        circle.Radius = _radius;
        _wasInside = IsMouseOver();
    }

    #endregion

    #region Main

    public void Action()
    {
        if (_action == null) return;

        _action.UpdateMousePosition(_hit);
    }

    public void ChangeCursor(bool change)
    {
        if(change)
        {
            _lineRenderer.material = _onMaterial;
            Cursor.SetCursor(icon, _hotspot, CursorMode.Auto);
        } else
        {
            _lineRenderer.material = _offMaterial;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    #endregion

    #region Mouse Events
    private void CastRay()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _hit = Physics2D.GetRayIntersection(_ray);
        _direction = (Vector2)transform.position - _hit.point;
        _magnitude = _radius * _radius * transform.localScale.x * transform.localScale.y;
    }

    public bool IsMouseOver()
    {
        return _direction.sqrMagnitude < _magnitude;
    }

    public bool IsMouseEnter()
    {
        return (!_wasInside && IsMouseOver());
    }

    public bool IsMouseExit()
    {
        return (_wasInside && !IsMouseOver());
    }
    #endregion




    private Vector2 _hotspot;
    private bool _wasInside;

    private Ray _ray;
    private RaycastHit2D _hit;
    private Vector2 _direction;
    private float _magnitude;
    private LineRenderer _lineRenderer;

}
