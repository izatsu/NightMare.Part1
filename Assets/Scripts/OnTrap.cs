using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrap : MonoBehaviour
{
    [SerializeField] private GameObject a;
    [SerializeField] private float delayTime = 0.5f;

    void Start()
    {
        
    }


    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(delay());
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(delayTime);
        a.SetActive(true);
    } 
        
}
