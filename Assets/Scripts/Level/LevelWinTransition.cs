using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelWinTransition : MonoBehaviour
{
    public void Awake()
    {
        _winEvents = FindObjectsOfType(typeof(WinEvent)) as WinEvent[];
    }

    public void Win()
    {
        foreach (WinEvent winEvent in _winEvents)
        {
            winEvent.OnWin();
        }
    }

    private WinEvent[] _winEvents;
}
