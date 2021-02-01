using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
   public void LoadScene(string name)
    {
        if (name == null)
        {
            Debug.LogWarning("Tried to load a scene with no name");
            return;
        }
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
