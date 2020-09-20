using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI gameTimeTxt = null;
    
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
        }
        
    }

    public void StartGame()
    {
        isGameStarted = true;
    }

    public void EndGame()
    {
        isGameStarted = false;
    }
}
