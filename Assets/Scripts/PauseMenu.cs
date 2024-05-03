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
        if (Gamepad.current != null && Gamepad.current.buttonNorth.wasPressedThisFrame)
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

        // Handle gamepad input for scene change (X button)
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
}
