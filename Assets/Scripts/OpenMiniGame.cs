using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMiniGame : MonoBehaviour
{
    public GameObject Text;
    private bool OnMiniGame = false;
    public GameObject level3;
    public GameObject hideObject;

    /*public void Awake()
    {
        ChangeSceneManager.Instance.OnChangeBackScene += LoadGame;
    }*/

    public void Start()
    {
        ChangeSceneManager.Instance.OnChangeBackScene += LoadGame;
    }

    private void LoadGame()
    {
        Debug.Log("Load gamer");
        level3.SetActive(true);
        hideObject.SetActive(true);
    }

    private void OnLevelFinishedLoading(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log(arg0.name);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && OnMiniGame)
        {
            SceneManager.LoadScene(3, LoadSceneMode.Additive);
            level3.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(3, LoadSceneMode.Additive);
            level3.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Text.SetActive(true);
            OnMiniGame = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Text.SetActive(false);
            OnMiniGame = false;
        }
    }

}
