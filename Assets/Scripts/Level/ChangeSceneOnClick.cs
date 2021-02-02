using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SceneChange))]
public class ChangeSceneOnClick : MonoBehaviour
{
    private void Awake()
    {
        _sceneManager = GetComponent<SceneChange>();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            _sceneManager.NextScene();
        }
    }

    private SceneChange _sceneManager;
}
