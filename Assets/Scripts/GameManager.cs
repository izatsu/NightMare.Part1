using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject MenuPauseGame;
    [SerializeField] private GameObject winGame;


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void MainLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }


    public void Level1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void Level2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        MenuPauseGame.SetActive(true);
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        MenuPauseGame.SetActive(false);
    }

    public void WinGame()
    {
        Time.timeScale = 0;
        winGame.SetActive(true);
    } 
        

}
