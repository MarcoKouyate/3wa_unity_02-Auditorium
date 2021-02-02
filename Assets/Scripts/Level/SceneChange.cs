using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
   public void LoadScene(string name)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        if (name == null)
        {
            Debug.LogWarning("Tried to load a scene with no name");
            return;
        }
        SceneManager.LoadScene(name);
    }

    public void NextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        } else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
