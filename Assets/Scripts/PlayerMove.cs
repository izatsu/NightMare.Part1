using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontal;
    private float speed = 12f;
    private float jumpingPower = 24f;
    private bool isFacingRight = true;

    private bool doubleJump = true;


    private bool canDash = true;
    private bool isDashing;
    private float DashingPower = 50f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;


    //Biến lưu điểm hồi sinh
    private Transform respawn_point;

    //Animation
    public Animator animator;

    


  

    // Update is called once per frame
    void Update()
    {

        // di chuyen
        horizontal = Input.GetAxis("Horizontal");


        //Nhay
        if (isGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
            CloseJump();
        }

        if (isDashing)
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

                doubleJump = !doubleJump;
            }
            animator.SetBool("isJump", true);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }


        // Luot 
        if (Input.GetKey(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }


        //Lat mat
        Flip();


        //Animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
         

         
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void CloseJump()
    {
        animator.SetBool("isJump", false);
    } 
        

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * DashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "respawn_point")
        {
            respawn_point = collision.transform;
        }

        if (collision.tag == "Thorn")
        {
            gameObject.transform.position = respawn_point.position;                      
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            gameObject.transform.position = respawn_point.position;
            Destroy(collision.gameObject);
        }    
            
    }    
}