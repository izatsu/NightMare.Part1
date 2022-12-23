using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public Ball_miniGame ball;
    public GameObject MainGameWin;
    public GameObject MiniGame;
    public GameObject level3;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball_miniGame>().GetComponent<Ball_miniGame>();

    }

    private void Update()
    {
        if (ball.isLose)
        {
            ResetGame();
        }

        if (ball.countBrick <= 0)
        {
            Time.timeScale = 0;
            WinGame();
            ball.countBrick = 110;
        }


    }

    public void ResetGame()
    {

        SceneManager.LoadScene(4);
    }

    public void WinGame()
    {
        MainGameWin.SetActive(true);
    }

    public void BacktoGame()
    {
        Time.timeScale = 1;
        MiniGame.SetActive(false);
    //    level3.SetActive(true);
        ChangeSceneManager.Instance.OnChangeBackScene?.Invoke();
    }



}
