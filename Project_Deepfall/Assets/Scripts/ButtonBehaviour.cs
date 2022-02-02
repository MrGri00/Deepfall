using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonBehaviour : MonoBehaviour
{
    [Header("Canvas Panels")]
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private Canvas settingsCanvas;
    [SerializeField] private RectTransform gameOverPanel;

    [Header("Submit Score Stuff")]
    [SerializeField] private ScoreManager playerScoreManager;
    [SerializeField] private InputField usernameInputField;
    [SerializeField] private Text warningText;


    InputSystemKeyboard inputSystem = null;
    HealthManager playerHealthManager = null;

    private void Awake()
    {
        if (FindObjectOfType<InputSystemKeyboard>())
        {
            inputSystem = FindObjectOfType<InputSystemKeyboard>();
            playerHealthManager = inputSystem.gameObject.GetComponent<HealthManager>();
        }

        if (usernameInputField != null)
            usernameInputField.characterLimit = 20;
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

    public void SubmitScore()
    {
        if (usernameInputField.text == "")
        {
            warningText.gameObject.SetActive(true);
        }
        else
        {
            ScoreDatabase.CreateDB();
            ScoreDatabase.DBAddScore(usernameInputField.text, playerScoreManager.score);

            EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Button>().interactable = false;
        }
    }

    void DeathMenu()
    {
        pauseCanvas.gameObject.SetActive(false);
        settingsCanvas.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
    }
}

