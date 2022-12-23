using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad_Right : MonoBehaviour
{
    public float bounce = 40f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * bounce, ForceMode2D.Impulse);
        }

    }
}
