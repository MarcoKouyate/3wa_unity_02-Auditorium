using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectorsSelectionManager : MonoBehaviour
{

    private void Awake()
    {
        GameObject[] effectors = GameObject.FindGameObjectsWithTag("Effector");
        _effectorSelectors = new EffectorSelector[effectors.Length];

        for (int i = 0; i < effectors.Length; i++)
        {
            _effectorSelectors[i] = effectors[i].GetComponent<EffectorSelector>();
        }
    }

    private void Update()
    {
        Select();
    }

    private void Select()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _selection = GetSelection();

        }

        if (Input.GetMouseButtonUp(0))
        {
            _selection.ChangeCursor(false);
            _selection = null;
            
        }

        if (_selection == null) return;

        _selection.ChangeCursor(true);
        _selection.Action();
    }

    private CursorSelector GetSelection()
    {
        CursorSelector cursor = null;
        foreach (EffectorSelector effectorSelector in _effectorSelectors)
        {
            if (effectorSelector.isSelected)
            {
                cursor = effectorSelector.SelectedCursor;
            }
        }

        return cursor;
    }

    private CursorSelector _selection;
    private EffectorSelector[] _effectorSelectors;
}
