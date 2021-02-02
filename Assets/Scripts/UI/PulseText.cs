using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class PulseText : MonoBehaviour
{

    [SerializeField] float _pulseMagnitude;

    [Min(0)]
    [SerializeField] float _pulseSpeed;

    private void Awake()
    {
        _textMesh = GetComponent<TMP_Text>();
        _originalFontSize = _textMesh.fontSize;
        _fontSize = _originalFontSize;
        _increment = _pulseSpeed;
    }

    private void Update()
    {
        if(_fontSize > _originalFontSize + _pulseMagnitude)
        {
            _increment = _pulseSpeed * -1;
        } else if(_fontSize < _originalFontSize)
        {
            _increment = _pulseSpeed;
        }

        _fontSize += _increment * Time.deltaTime;
        _textMesh.fontSize = _fontSize;
    }

    private float _fontSize;
    private float _increment;
    private TMP_Text _textMesh;
    private float _originalFontSize;
}
