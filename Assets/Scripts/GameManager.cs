using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI = null;
    [SerializeField] private GameObject gamePlayUI = null;
    [SerializeField] private GameObject gameOverUI = null;
    [SerializeField] private GameObject playerSpawner = null;
    [SerializeField] private GameObject enemySpawner = null;

    [SerializeField] private TextMeshProUGUI mainMenuHighScore = null;
    [SerializeField] private TextMeshProUGUI gameTimeTxt = null;
    [SerializeField] private TextMeshProUGUI gameOverTimeTxt = null;


    [SerializeField] private GameObject mainMenuMuteBtn = null;
    [SerializeField] private GameObject mainMenuUnMuteBtn = null;
    [SerializeField] private GameObject gameMuteBtn = null;
    [SerializeField] private GameObject gameUnMuteBtn = null;

    [SerializeField] private GameObject helpText = null;

    public int allTimeHighScoreMinutes;
    public int allTimeHighScoreSeconds;

    public bool isGameStarted = false;
    public static bool isGameOver = false;
    private float lastScoreMin = 0f;
    private float lastScoreSec = 0f;
    private int minutes = 0;
    private float seconds = 0f;

    public static float timePlayed;
    // Start is called before the first frame update
    void Start()
    {
        minutes = 0;
        seconds = 0f;
        GetHighScore();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            if (!isGameOver)
            {
                seconds += Time.deltaTime;
                if (seconds > 59)
                {
                    seconds = 0;
                    minutes++;
                }
                gameTimeTxt.SetText((minutes.ToString().Length > 1 ? minutes.ToString() : "0" + minutes.ToString()) + ":" + (((int)seconds).ToString().Length > 1 ? ((int)seconds).ToString() : "0" + ((int)seconds).ToString()));
                lastScoreMin = minutes;
                lastScoreSec = seconds;
            }
            else
            {
                // set game over UI 
                gameOverUI.SetActive(true);
                gamePlayUI.SetActive(false);
                gameOverTimeTxt.SetText("Score: " + (lastScoreMin.ToString().Length > 1 ? lastScoreMin.ToString() : "0" + lastScoreMin.ToString()) + ":" + (((int)lastScoreSec).ToString().Length > 1 ? ((int)lastScoreSec).ToString() : "0" + ((int)lastScoreSec).ToString()));
                SetHighScore();
                GetHighScore();

                DestroyEnemyObjects();
                //reset timer
                minutes = 0;
                seconds = 0;
                




            }


        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mainMenuUI.activeInHierarchy)
            {
                Application.Quit();
            }
            else
            {
                BackToMainMenuBtn();
            }

        }
            

    }

    public void StartGame()
    {
        isGameStarted = true;
        playerSpawner.SetActive(true);
        enemySpawner.SetActive(true);
        Invoke("ShowHideHelpText", 3);

    }

    public void EndGame()
    {
        DestroyEnemyObjects();
        DestroyPlayerObjects();
        isGameStarted = false;
        isGameOver = true;
        //deactivate spawners
        playerSpawner.SetActive(false);
        enemySpawner.SetActive(false);
        PlayerSpawnerController.pCount = 0;
        EnemySpawner.ResetCount();
        BoostSpawner.ResetCount();

    }

    public void RestartGameBtn()
    {
        Debug.Log("restart");
        DestroyEnemyObjects();
        DestroyPlayerObjects();
        gameOverUI.SetActive(false);
        gamePlayUI.SetActive(true);
        playerSpawner.SetActive(true);
        enemySpawner.SetActive(true);
        isGameOver = false;
        isGameStarted = true;
        PlayerSpawnerController.pCount = 0;
        EnemySpawner.ResetCount();
        BoostSpawner.ResetCount();
    }

    public void BackToMainMenuBtn()
    {
        EndGame();
        minutes = 0;
        seconds = 0;
        isGameOver = false;
        isGameStarted = false;
        gameOverUI.SetActive(false);
        gamePlayUI.SetActive(false);
        mainMenuUI.SetActive(true);
        PlayerSpawnerController.pCount = 0;
        EnemySpawner.ResetCount();
        BoostSpawner.ResetCount();

    }

    public void MuteAllBtn()
    {
        AudioListener.volume = 0;

        mainMenuMuteBtn.SetActive(false);
        mainMenuUnMuteBtn.SetActive(true);
        gameMuteBtn.SetActive(false);
        gameUnMuteBtn.SetActive(true);

    }

    public void UnmuteAllBtn()
    {
        AudioListener.volume = 1;

        mainMenuMuteBtn.SetActive(true);
        mainMenuUnMuteBtn.SetActive(false);
        gameMuteBtn.SetActive(true);
        gameUnMuteBtn.SetActive(false);
    }


    public void ExitBtn()
    { 
        Application.Quit();
    }

    private void GetPreviousHighScore()
    {
        //TODO
        Debug.Log("TODO");
    }

    private void SetHighScore()
    {
        if (allTimeHighScoreMinutes <= lastScoreMin)
        {
            if (allTimeHighScoreSeconds <= lastScoreSec)
            {
                PlayerPrefs.SetInt("Minutes", (int)lastScoreMin);
                PlayerPrefs.SetInt("Seconds", (int)lastScoreSec);
            }
        }

        
        
    }

    public void GetHighScore()
    {
        allTimeHighScoreMinutes = PlayerPrefs.GetInt("Minutes");
        allTimeHighScoreSeconds = PlayerPrefs.GetInt("Seconds");
        mainMenuHighScore.SetText("High Score: " + (allTimeHighScoreMinutes.ToString().Length > 1 ? allTimeHighScoreMinutes.ToString() : "0" + allTimeHighScoreMinutes.ToString()) + ":" + (((int)allTimeHighScoreSeconds).ToString().Length > 1 ? ((int)allTimeHighScoreSeconds).ToString() : "0" + ((int)allTimeHighScoreSeconds).ToString()));
    }


    public void DestroyEnemyObjects()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in allObjects)
        {
            Destroy(obj);
        }
    }

    private void DestroyPlayerObjects()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject obj in allObjects)
        {
            Destroy(obj);
        }
    }


    private void ShowHideHelpText()
    {
        helpText.SetActive(false);
    }
}
