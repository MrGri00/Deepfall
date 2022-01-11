using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
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
        Time.timeScale = 0f;
        
        gameObject.SetActive(true);
    }

    public void CloseCanvas()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        //SceneManager.LoadScene("Game");
        SceneTransition.GoToScene("Game");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void FindCanvas()
    {

    }
}

