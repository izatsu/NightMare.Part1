using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_right : MonoBehaviour
{

    [SerializeField] private float speed = 2f;
    [SerializeField] private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.AddForce(Vector2.right* speed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }    
    }
}
