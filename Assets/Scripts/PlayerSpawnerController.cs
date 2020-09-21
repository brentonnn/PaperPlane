using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject player = null;
    // Start is called before the first frame update
    public static int pCount = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (pCount < 1)
        {
            Instantiate(player, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            pCount++;
        } 
    }
}
