using UnityEngine;
using UnityEngine.UI;

public enum WindowType { MAIN_MENU, PAUSE_MENU, END_GAME_MENU}

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject topPanel;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text endGameScoreText;
    [SerializeField]
    private GameObject mainMenuWindow;
    [SerializeField]
    private GameObject pauseMenuWindow;
    [SerializeField]
    private GameObject endGameWindow;

    public static MenuManager instance;
    private void Start()
    {
        InitializeMenuManager();
    }
    private void InitializeMenuManager()
    {
        if (instance == null)
        {
            instance = this;
        }

        ShowWindow(WindowType.MAIN_MENU);
        HideWindow(WindowType.PAUSE_MENU);
        HideWindow(WindowType.END_GAME_MENU);
    }
    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void SetEndGameScore(int score)
    {
        endGameScoreText.text = string.Format("Your score: \n {0}", score);
    }
    public void ShowWindow(WindowType windowType)
    {
        switch (windowType)
        {
            case (WindowType.MAIN_MENU):
                mainMenuWindow.SetActive(true);
                topPanel.SetActive(false);
                break;
            case (WindowType.PAUSE_MENU):
                pauseMenuWindow.SetActive(true);
                break;
            case (WindowType.END_GAME_MENU):
                endGameWindow.SetActive(true);
                topPanel.SetActive(false);
                break;
        }
    }
    public void HideWindow(WindowType windowType)
    {
        switch (windowType)
        {
            case (WindowType.MAIN_MENU):
                mainMenuWindow.SetActive(false);
                topPanel.SetActive(true);
                break;
            case (WindowType.PAUSE_MENU):
                pauseMenuWindow.SetActive(false);
                break;
            case (WindowType.END_GAME_MENU):
                endGameWindow.SetActive(false);
                break;
        }
    }
}
