using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    
    [SerializeField] private float movementSpeed = 0f;
    [SerializeField] private float rotationSpeed = 0f;
    [SerializeField] private float enemyBoundsX = 3.25F;
    [SerializeField] private float enemyBoundsY = 6f;

    [SerializeField] private float minTime = 6;
    [SerializeField] private float maxTime = 12;
    
    
    private bool isDestroyed = false;
    private Vector3 targetPos = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector2(Random.Range(-enemyBoundsX, enemyBoundsX), Random.Range(-enemyBoundsY, enemyBoundsY));
        Invoke("Disappear", Random.Range(minTime, maxTime));
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDestroyed)
        {
            if (Vector2.Distance(transform.position, targetPos) < 0.1f)
            {
                targetPos = new Vector2(Random.Range(-enemyBoundsX, enemyBoundsX), Random.Range(-enemyBoundsY, enemyBoundsY));
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
            }

            transform.Rotate(Vector3.forward * rotationSpeed);
        }
    }


    private void Disappear()
    {
        Destroy(gameObject);
    }
}
