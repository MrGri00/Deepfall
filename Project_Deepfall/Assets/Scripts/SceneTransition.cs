using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneTransition
{
    public static void NextScene()
    {
        GC.Collect();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void PreviousScene()
    {
        GC.Collect();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public static void ReloadScene()
    {
        GC.Collect();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public static void GoToScene(int sceneIndex)
    {
        GC.Collect();
        SceneManager.LoadScene(sceneIndex);
    }

    public static void GoToScene(string sceneName)
    {
        GC.Collect();
        SceneManager.LoadScene(sceneName);
    }
}
