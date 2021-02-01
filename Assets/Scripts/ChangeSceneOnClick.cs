using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SceneChange))]
public class ChangeSceneOnClick : MonoBehaviour
{
    [SerializeField] private string nextScene;

    private void Awake()
    {
        _sceneManager = GetComponent<SceneChange>();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            _sceneManager.LoadScene(nextScene);
        }
    }

    private SceneChange _sceneManager;
}
