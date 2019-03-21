using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public int score;

    private bool gameStarted;
    private bool gameFinished;

    public static GameController instance;
    
    public bool GetGameStartedStatus()
    {
        return gameStarted;
    }
    public bool GetGameFinishedStatus()
    {
        return gameFinished;
    }

    public void StartGame()
    {
        MenuManager.instance.UpdateScoreText(score);
        MenuManager.instance.HideWindow(WindowType.MAIN_MENU);
        gameStarted = true;
        UnitController.instance.SpawnUnits();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        MenuManager.instance.ShowWindow(WindowType.PAUSE_MENU);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        MenuManager.instance.HideWindow(WindowType.PAUSE_MENU);
    }
    public void EndGame()
    {
        gameFinished = true;
        UnitController.instance.ReturnUnitsToPool();
        MenuManager.instance.SetEndGameScore(score);
        MenuManager.instance.ShowWindow(WindowType.END_GAME_MENU);
    }
    public void RestartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        MenuManager.instance.HideWindow(WindowType.END_GAME_MENU);
        MenuManager.instance.ShowWindow(WindowType.MAIN_MENU);
        InitializeGameController();
    }
    public void RestartGameFromPause()
    {
        ContinueGame();
        MenuManager.instance.ShowWindow(WindowType.MAIN_MENU);
        UnitController.instance.ReturnUnitsToPool();
        InitializeGameController();
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        MenuManager.instance.UpdateScoreText(this.score);
    }
    private void Start()
    {
        InitializeGameController();
        UnitController.instance.InitializePool();
    }
    private void InitializeGameController()
    {
        if (instance == null)
        {
            instance = this;
        }
        gameStarted = false;
        gameFinished = false;
        score = 0;
    }
}
