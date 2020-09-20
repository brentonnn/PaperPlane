using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float movementSpeed = 0f;
    [SerializeField] private float rotationSpeed = 0f;
    [SerializeField] private float playerBoundsX = 3.25F;
    [SerializeField] private float playerBoundsY = 6f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isGameOver)
        {
            Controls();

            PlayerWrapper();
        }
    }
    
    private void PlayerWrapper()
    {
        if (transform.position.x > playerBoundsX || transform.position.x < -playerBoundsX)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }
        if (transform.position.y > playerBoundsY || transform.position.y < -playerBoundsY)
        {
            transform.position = new Vector2(transform.position.x, -transform.position.y);
        }
    }

    private void Controls()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        if (TouchControlsHandler.left)
        {
            transform.Rotate(Vector3.forward * rotSpeed);
        }
        else if (TouchControlsHandler.right)
        {
            transform.Rotate(-Vector3.forward * rotSpeed);
        }
    }
}
