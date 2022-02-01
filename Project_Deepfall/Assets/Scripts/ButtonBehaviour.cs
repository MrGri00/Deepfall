using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private Canvas settingsCanvas;
    [SerializeField] private RectTransform gameOverPanel;

    InputSystemKeyboard inputSystem = null;
    HealthManager playerHealthManager = null;

    private void Awake()
    {
        if (FindObjectOfType<InputSystemKeyboard>())
        {
            inputSystem = FindObjectOfType<InputSystemKeyboard>();
            playerHealthManager = inputSystem.gameObject.GetComponent<HealthManager>();
        }
    }

    private void OnEnable()
    {
        if (inputSystem != null)
        {
            inputSystem.PauseGame += OpenPauseCanvas;
            playerHealthManager.Death += DeathMenu;
        }
    }

    private void OnDisable()
    {
        if (inputSystem != null)
        {
            inputSystem.PauseGame -= OpenPauseCanvas;
            playerHealthManager.Death -= DeathMenu;
        }
    }

    public void OpenPauseCanvas()
    {
        if (inputSystem != null)
        {
            inputSystem.isPaused = true;
            Time.timeScale = 0f;
        }
        pauseCanvas.gameObject.SetActive(true);
    }

    public void ClosePauseCanvas()
    {
        if (inputSystem != null)
        {
            inputSystem.isPaused = false;
            Time.timeScale = 1f;
        }
        pauseCanvas.gameObject.SetActive(false);
    }

    public void OpenSettingsCanvas()
    {
        settingsCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
    }

    public void CloseSettingsCanvas()
    {
        settingsCanvas.gameObject.SetActive(false);
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
        if (inputSystem != null)
        {
            inputSystem.isPaused = false;
            Time.timeScale = 1f;
        }
        SceneTransition.GoToScene(1);
    }

    public void Credits()
    {
        SceneTransition.GoToScene("Credits");
    }

    public void ResetScene()
    {
        inputSystem.isPaused = false;
        Time.timeScale = 1f;
        SceneTransition.ReloadScene();
    }

    public void CloseGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }

    void DeathMenu()
    {
        pauseCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
    }
}

