using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_bong : MonoBehaviour
{
    [SerializeField] private GameObject Ball;
    [SerializeField] private Transform pos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameObject b = Instantiate(Ball, pos);
            Destroy(b, 6f);
        }    
    }
}
