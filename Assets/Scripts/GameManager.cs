using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public GameObject gameOverUI;
    public GameObject GameWonUI;
    public TextMeshProUGUI objectivesTxt;

    public bool allTyresCollected;
    public bool allFuelCanCollected;
    public bool lockUnlocked;
    public bool HasKey;

    public int numberOfTyresCollected=0;
    public int numberOfFuelCanCollected=0;

    public int maxFuelCanNeeded;
    public int maxTyresNeeded;




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
        UpdateObjectivesUI();
    }

    public void UpdateObjectivesUI()
    {
        int noOfKeys = HasKey ? 1 : 0;
        string LockStatus = lockUnlocked ? "unlocked" : "locked";

        objectivesTxt.text = "Tyres Collected " + numberOfTyresCollected + " | Tyres Needed " + maxTyresNeeded +
            "\nFuelCans Collected " + numberOfFuelCanCollected + " | FuelCans Needed " + maxFuelCanNeeded +
            "\nKeys Colleceted "+noOfKeys+" | keys Needed 1\nLock Unlocked "+LockStatus;
    }

    public void CheckWinCondition()
    {
        if (numberOfFuelCanCollected>=maxFuelCanNeeded)
        {
            allFuelCanCollected = true;
        }
        if (numberOfTyresCollected >= maxTyresNeeded)
        {
            allTyresCollected = true;
        }
        if (allFuelCanCollected && allTyresCollected && lockUnlocked)
        {
            Debug.Log("you Won");
            GameWon();
        }
    }

    public void GameWon()
    {
        objectivesTxt.enabled=false;
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
