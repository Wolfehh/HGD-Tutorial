using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public AudioManager audioManager;

    private float moveSpeed = 8f;

    private float timeWait = 0;

    private Rigidbody2D rb;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (timeWait > 0)
        {
            timeWait -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        // Move Character

        movement.Normalize();
        rb.velocity = (movement * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && timeWait <= 0)
        {
            audioManager.Play("Bonk");
            Debug.Log("Collided");
            timeWait = 1f;
        }
    }
}
