using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToNextLevelOnWin : MonoBehaviour, IWinEvent
{
    private void Awake()
    {
        _action = GetComponent<ChangeSceneOnClick>();
    }

    public void OnWin()
    {
        if(_action == null)
        {
            _action= gameObject.AddComponent(typeof(ChangeSceneOnClick)) as ChangeSceneOnClick;
        }
    }

    private ChangeSceneOnClick _action;
}
