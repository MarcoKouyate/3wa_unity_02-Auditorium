﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillVisualizer : MonoBehaviour
{
    [SerializeField] private GameObject _colorBarPrefab;

    [Min(1)]
    [SerializeField] int _colorBarCount;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float amount;

    [Tooltip("Check this if you want to change opacity as well")]
    [SerializeField] private bool gradeOpacity;


    private void Awake()
    {
        CreateColorBars();
        _amountPerColorBar = amount / _colorBarCount;
    }

    private void Update()
    {
        FillColorBars();
    }



    public void Fill(float value)
    {
        amount = value;
    }

    public void SetMaterial(Material material)
    {
        foreach (FillColor colorBar in _colorBars)
        {
            colorBar.SetMaterial(material);
        }
    }


    private void CreateColorBars()
    {
        _colorBars = new List<FillColor>();
        Vector3 localScale = transform.localScale;
        float colorBarSize = localScale.y / _colorBarCount;
        float localPositionOffset = transform.localScale.y / 2;

        for (int i = 0; i < _colorBarCount; i++)
        {
            GameObject colorBar = Instantiate(_colorBarPrefab, transform);
            colorBar.transform.localScale = new Vector3(1, colorBarSize, 1);
            Vector3 verticalPosition = Vector3.up * (colorBarSize * (i + 0.5f) - localPositionOffset);
            colorBar.transform.Translate(verticalPosition, Space.Self);

            FillColor colorBarScript = colorBar.GetComponent<FillColor>();

            if (colorBarScript != null)
            {
                _colorBars.Add(colorBarScript);
            }
        }
    }

    private void FillColorBars()
    {
        float residual = amount;

        foreach (FillColor colorBar in _colorBars)
        {
            float colorBarAmount = _amountPerColorBar;

            if (residual < _amountPerColorBar)
            {
                colorBarAmount = residual % _amountPerColorBar;
            }

            residual -= colorBarAmount;

            colorBar.amount = colorBarAmount * (GetMaxOpacity() / _amountPerColorBar);
        }
    }

    private float GetMaxOpacity()
    {
        if (gradeOpacity)
        {
            return amount;
        } else
        {
            return 1;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    private List<FillColor> _colorBars;
    private float _amountPerColorBar;
}
