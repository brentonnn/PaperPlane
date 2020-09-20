using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
