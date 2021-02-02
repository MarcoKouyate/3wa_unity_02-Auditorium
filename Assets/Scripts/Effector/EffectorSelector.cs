using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(CircleShape))]
public class EffectorSelector : MonoBehaviour
{
    [SerializeField] CursorSelector[] _cursorSelectors;

    public CursorSelector SelectedCursor {
        get => GetCursorSelected();
    }

    public bool isSelected
    {
        get => GetCursorSelected() != null;
    }


    private CursorSelector GetCursorSelected()
    {
        float activeRadius = 0;
        CursorSelector currentCursorSelector = null;

        foreach (CursorSelector cursorSelector in _cursorSelectors)
        {
            if ((activeRadius == 0 || cursorSelector.Radius < activeRadius) && cursorSelector.IsMouseOver())
            {
                activeRadius = cursorSelector.Radius;
                currentCursorSelector = cursorSelector;
            }
        }

        return currentCursorSelector;
    }

    // Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
}
