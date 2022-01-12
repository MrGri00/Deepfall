using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    private Canvas canvasToToggle;
    
    InputSystemKeyboard inputSystem = null;

    private void Awake()
    {
        if (FindObjectOfType<InputSystemKeyboard>())
            inputSystem = FindObjectOfType<InputSystemKeyboard>();
    }

    private void OnEnable()
    {
        inputSystem.PauseGame += OpenCanvas;
    }

    private void OnDisable()
    {
        inputSystem.PauseGame -= OpenCanvas;
    }

    public void OpenCanvas()
    {
        if (inputSystem != null)
        {
            inputSystem.isPaused = true;
            Time.timeScale = 0f;
        }
        canvasToToggle.gameObject.SetActive(true);
    }

    public void CloseCanvas()
    {
        if (inputSystem != null)
        {
            inputSystem.isPaused = false;
            Time.timeScale = 1f;
        }
        canvasToToggle.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        if (inputSystem != null)
        {
            inputSystem.isPaused = false;
            Time.timeScale = 1f;
        }
        SceneTransition.GoToScene("Game");
    }

    public void MainMenu()
    {
        inputSystem.isPaused = false;
        Time.timeScale = 1f;
        SceneTransition.GoToScene(0);
    }

    public void ResetScene()
    {
        inputSystem.isPaused = false;
        Time.timeScale = 1f;
        SceneTransition.ReloadScene();
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}

