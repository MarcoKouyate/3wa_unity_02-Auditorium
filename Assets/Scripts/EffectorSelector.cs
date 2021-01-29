using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(CircleShape))]
public class EffectorSelector : MonoBehaviour
{

    [SerializeField] CursorSelector[] _cursorSelectors;

    private void Update()
    {
        float activeRadius = 0;
        CursorSelector currentCursorSelector = null;

        foreach (CursorSelector cursorSelector in _cursorSelectors)
        {
            if((activeRadius == 0 ||  cursorSelector.Radius < activeRadius) && cursorSelector.IsMouseOver())
            {
                activeRadius = cursorSelector.Radius;
                currentCursorSelector = cursorSelector;
            }
        }

        if(currentCursorSelector != null)
        {
            currentCursorSelector.ChangeCursor();
            currentCursorSelector.Action();

        } else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
