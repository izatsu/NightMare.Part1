using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLand : MonoBehaviour
{
    public GameObject land;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PushBlock"))
        {
            land.SetActive(false);
        }    
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PushBlock"))
            land.SetActive(true);
    }
}
