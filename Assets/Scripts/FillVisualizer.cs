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


    private void Start()
    {

        CreateColorBars();
        _amountPerColorBar = amount / _colorBarCount;
    }

    private void Update()
    {
        FillColorBars();
    }



    private void CreateColorBars()
    {
        _colorBars = new List<FillColor>();
        Vector3 localScale = transform.localScale;
        float colorBarSize = localScale.y / _colorBarCount;

        for (int i = 0; i < _colorBarCount; i++)
        {
            GameObject colorBar = Instantiate(_colorBarPrefab, transform);
            colorBar.transform.localScale = new Vector3(1, colorBarSize, 1);
            colorBar.transform.Translate(Vector3.up * colorBarSize * i, Space.Self);

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

            colorBar.amount = colorBarAmount * (amount / _amountPerColorBar);
        }
    }

    private List<FillColor> _colorBars;
    private float _amountPerColorBar;
}
