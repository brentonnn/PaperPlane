using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{

    [SerializeField] private int maxCount = 0;

    [SerializeField] private GameObject[] boosts = null;

    [SerializeField] public static float minTime = 1f, maxTime = 6f;

    public static int count = 0;
    private static float tempTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        tempTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (tempTime <= 0 && maxCount > count)
        {
            // get random number for random enemy
            int boostNum = Mathf.RoundToInt(Random.Range(0f, boosts.Length - 1));
            //Instantiate(enemies[enemyNum], Vector2.zero, Quaternion.identity);
            Instantiate(boosts[boostNum], new Vector2(Random.Range(0, 2), Random.Range(0, 3)), Quaternion.identity);
            count++;

            tempTime = Random.Range(minTime, maxTime);
        }
        else if (maxCount > count)
        {
            tempTime -= Time.deltaTime;
        }
    }

    public static void ResetCount()
    {
        count = 0;
        tempTime = Random.Range(minTime, maxTime);
    }
}
