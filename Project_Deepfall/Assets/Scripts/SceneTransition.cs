using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneTransition
{
    public static void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void PreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public static void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
