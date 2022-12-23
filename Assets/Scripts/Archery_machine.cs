using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archery_machine : MonoBehaviour
{
    [SerializeField] private GameObject Arrow_prefabs;
    [SerializeField] private float Time_gun = 1.5f;
    [SerializeField] private Transform point;

    void Update()
    {
        Time_gun -= Time.deltaTime;
        if (Time_gun <= 0)
        {
            Instantiate(Arrow_prefabs, point.position, Quaternion.identity);
            Time_gun = 1.5f;
        }
    }
}
