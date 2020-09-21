using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int maxCount = 0;
    
    [SerializeField] private GameObject[] enemies = null;

    [SerializeField] private float minTime = 0f, maxTime = 0f;

    private int count = 0;
    private float tempTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        tempTime = Random.Range(minTime, maxTime);
        int enemyNum = Mathf.RoundToInt(Random.Range(0f, enemies.Length - 1));
        //Instantiate(enemies[enemyNum], new Vector2(Random.Range(0, 3), Random.Range(0, 3)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (tempTime <= 0 && maxCount > count)
        {
            // get random number for random enemy
            int enemyNum = Mathf.RoundToInt(Random.Range(0f, enemies.Length-1));
            //Instantiate(enemies[enemyNum], Vector2.zero, Quaternion.identity);
            Instantiate(enemies[enemyNum], new Vector2(Random.Range(0, 2), Random.Range(0, 3)), Quaternion.identity);
            count++;
            
            //tempTime = Random.Range(minTime, maxTime);
        }
        else if(maxCount > count)
        {
            tempTime -= Time.deltaTime;
        }
    }
}
