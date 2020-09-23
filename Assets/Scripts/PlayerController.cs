using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float movementSpeed = 0f;
    [SerializeField] private float rotationSpeed = 0f;
    [SerializeField] private float playerBoundsX = 3.25F;
    [SerializeField] private float playerBoundsY = 6f;

    [SerializeField] private AudioSource playerDeathAudio = null;

    [SerializeField] private SpriteRenderer sr = null;
    [SerializeField] private Sprite sp = null;

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

        if (gameObject.transform.position.y < -8)
        {
            Destroy(gameObject);
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
        transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
        if (ControlHandler.left)
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if (ControlHandler.right)
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            PlayerSpawnerController.pCount = 0;
            GameManager.isGameOver = true;
            PlayerDeath();
            rotationSpeed *= 2;
            ControlHandler.left = false;
            ControlHandler.right = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        
    }

    private void PlayerDeath()
    {
        playerDeathAudio.Play();
        sr.sprite = sp;
    }
}
