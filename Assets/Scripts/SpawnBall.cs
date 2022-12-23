using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] private GameObject ball_prefabs;

    private float time = 3.5f; 


    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            GameObject a = Instantiate(ball_prefabs, transform.position, Quaternion.identity);
            Destroy(a, 30f);
            time = 3.5f;
        } 
            
    }


   
        

}
