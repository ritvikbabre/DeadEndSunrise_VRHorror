using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;
    public bool cursorLocked = false;
    private bool gameStarted = false; // Track if the game has started
    private bool northButtonClicked = false; // Track if the North button has been clicked

    void Start()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        cursorLocked = true;
    }

    void Update()
    {
        // Handle keyboard input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
            ToggleCursorLock();
        }

        // Handle gamepad input for pause/resume
        if (Gamepad.current != null && Gamepad.current.buttonNorth.wasPressedThisFrame && !northButtonClicked)
        {
            if (gameStarted) // Check if the game has started
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                Debug.Log("North button is pressed");
            }
            else // If the game has not started, open the main menu
            {
                OpenMainMenu();
            }
            northButtonClicked = true; // Set to true to indicate that the North button has been clicked
        }

        // Check if the game is not paused before allowing X button on the gamepad to work
        if (!Paused && Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Debug.Log("X is pressed");
        }
    }

    void ToggleCursorLock()
    {
        cursorLocked = !cursorLocked;
        Cursor.lockState = cursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }

    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        Cursor.visible = true;
    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        Cursor.visible = false;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Has been Quit The Game");
    }

    public void StartGame()
    {
        gameStarted = true;
    }

    public void OpenMainMenu()
    {
        // Open the main menu
        Debug.Log("Main menu is opened");
    }
}
