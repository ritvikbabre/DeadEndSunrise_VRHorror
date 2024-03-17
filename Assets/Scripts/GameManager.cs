using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public GameObject gameOverUI;
    public GameObject GameWonUI;

    public bool allTyresCollected;
    public bool allFuelCanCollected;
    public bool lockUnlocked;



    private void Awake()
    {
        if(Instance == null) { Instance = this; }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckWinCondition()
    {
        if (allFuelCanCollected && allTyresCollected && lockUnlocked)
        {
            Debug.Log("you Won");
        }
    }

    public void GameWon()
    {
        GameWonUI.SetActive(true);
        
    }

    public void GAMEOVER()
    {
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
