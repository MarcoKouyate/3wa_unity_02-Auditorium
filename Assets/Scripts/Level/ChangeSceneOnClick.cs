using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SceneChange))]
public class ChangeSceneOnClick : MonoBehaviour
{
    [SerializeField] private string _nextScene;

    public string NextScene
    {
        get => _nextScene;
        set => _nextScene = value;
    } 

    private void Awake()
    {
        _sceneManager = GetComponent<SceneChange>();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            _sceneManager.LoadScene(_nextScene);
        }
    }

    private SceneChange _sceneManager;
}
