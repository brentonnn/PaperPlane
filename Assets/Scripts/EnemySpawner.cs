using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int maxCount;
    
    [SerializeField] private GameObject[] enemies;

    [SerializeField] private float minTime, maxTime;

    private int count = 0;
    private float tempTime = 0;
    
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
            int enemyNum = Mathf.RoundToInt(Random.Range(0f, enemies.Length-1));
            Instantiate(enemies[enemyNum], Vector2.zero, Quaternion.identity);
            count++;
            
            tempTime = Random.Range(minTime, maxTime);
        }
        else if(maxCount > count)
        {
            tempTime -= Time.deltaTime;
        }
    }
}
