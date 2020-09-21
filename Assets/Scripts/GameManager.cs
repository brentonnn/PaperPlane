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


    [SerializeField] private TextMeshProUGUI gameTimeTxt = null;
    [SerializeField] private TextMeshProUGUI gameOverTimeTxt = null;

    public bool isGameStarted = false;
    public static bool isGameOver = false;
    private int minutes = 0;
    private float seconds = 0f;

    public static float timePlayed;
    // Start is called before the first frame update
    void Start()
    {
        minutes = 0;
        seconds = 0f;
        
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
            }
            else
            {
                // set game over UI 
                gameOverUI.SetActive(true);
                gamePlayUI.SetActive(false);
                gameOverTimeTxt.SetText((minutes.ToString().Length > 1 ? minutes.ToString() : "0" + minutes.ToString()) + ":" + (((int)seconds).ToString().Length > 1 ? ((int)seconds).ToString() : "0" + ((int)seconds).ToString()));

                //reset timer
                minutes = 0;
                seconds = 0;

                

            }


        }


        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }

    public void StartGame()
    {
        isGameStarted = true;
        playerSpawner.SetActive(true);
        enemySpawner.SetActive(true);

    }

    public void EndGame()
    {
        isGameStarted = false;
        //deactivate spawners
        playerSpawner.SetActive(false);
        enemySpawner.SetActive(false);
    }

    public void BackToMainMenuBtn()
    {
        isGameOver = false;
        isGameStarted = false;
        gameOverUI.SetActive(false);
        gamePlayUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void MuteAllBtn()
    {
        AudioListener.volume = 0;
    }

    public void UnmuteAllBtn()
    {
        AudioListener.volume = 1;
    }


    public void ExitBtn()
    { 
        Application.Quit();
    }
}
