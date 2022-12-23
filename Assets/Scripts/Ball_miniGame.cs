using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_miniGame : MonoBehaviour
{

    public Rigidbody2D rb;
    [SerializeField] private float BallForce;


    bool inPlay;
    public Transform paddle;

    public int health = 3;
    public bool isLose = false;

    public int countBrick = 110;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlay)
            transform.position = paddle.position;
        if(Input.GetButtonDown("Jump") && (!inPlay))
        {
            inPlay = true;
            rb.AddForce(Vector2.up * 500);
        }

        if (health <= 0) isLose = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bottom"))
        {
            rb.velocity = Vector2.zero;
            inPlay = false;
            health--;
        } 
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            countBrick--;
        }
    }
}
