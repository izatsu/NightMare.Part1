using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_miniGame : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed_move;

    private float horizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed_move, rb.velocity.y);
    }



}
