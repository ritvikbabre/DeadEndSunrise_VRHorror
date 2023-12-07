using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewBehaviourScript : MonoBehaviour
{
    //load Game
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 

    //Quit Game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Has Quite The Game");
    }
}
