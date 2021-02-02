using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToNextLevelOnWin : MonoBehaviour, IWinEvent
{
    [SerializeField] private string _nextScene;

    public void OnWin()
    {
        if(_action == null)
        {
            _action= gameObject.AddComponent(typeof(ChangeSceneOnClick)) as ChangeSceneOnClick;
            _action.NextScene = _nextScene;
        }
    }

    private ChangeSceneOnClick _action;
}
