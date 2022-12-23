using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffTrap : MonoBehaviour
{
    [SerializeField] private GameObject a;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            a.SetActive(false);
        }
    }

}
