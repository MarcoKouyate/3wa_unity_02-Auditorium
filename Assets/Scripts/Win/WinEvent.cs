using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(IWinEvent))]
public class WinEvent : MonoBehaviour
{
    private void Awake ()
    {
        _attachedEvent = GetComponent<IWinEvent>();
    }

    public void OnWin()
    {
        _attachedEvent.OnWin();
    }

    private IWinEvent _attachedEvent;
}
